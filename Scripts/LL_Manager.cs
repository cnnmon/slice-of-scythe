using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LL_Manager : MonoBehaviour
{
    readonly int totalTime = 20; //total time needed to complete minigame
    readonly float waitTimeMultiplier = 0.98f; //multiplied to decrease waitTime each time
    private float waitTime = 3f; //decreased for difficulty
    readonly float spawnX = 9f; //spawned at this X value

    public int lives = 4;
    public bool isPlaying = true;

    [Header("Spawning")]
    public Transform spawnGroup;
    public GameObject[] enemies;
    private List<GameObject> spawnedEnemies = new List<GameObject>();

    [Header("GUI")]
    public GameObject endScreen;
    public TextMeshProUGUI livesText;
    public Text endText;

    [Header("TIMER")]
    public Image loading;
    public TextMeshProUGUI timeText;
    private int sec;
    private int seconds = 0;
    private int totalSeconds = 0;

    private void Start()
    {
        UpdateLives();
        StartCoroutine("SpawnEnemies");

        //TIMER//
        sec = totalTime;
        timeText.text = sec.ToString("00");
        if (sec > 0) seconds += sec;
        totalSeconds = seconds;
        StartCoroutine("Second");
    }

    private void Update()
    {
        //if timer has run out
        if (sec == 0) EndGame(true);
    }

    private IEnumerator SpawnEnemies()
        //spawns enemies at interval waitTime
    {
        while (true)
        {
            GameObject spawn = Instantiate(enemies[Random.Range(0, enemies.Length)], spawnGroup);
            spawn.transform.position = new Vector2(spawnX, spawn.transform.position.y);
            spawnedEnemies.Add(spawn);
            waitTime *= waitTimeMultiplier;
            yield return new WaitForSeconds(waitTime);
        }
    }

    public void UpdateLives()
    {
        lives--;

        string livesString = "";
        for (int i = 0; i < lives; i++) livesString += "x";
        livesText.text = livesString;

        if (lives <= 0) EndGame(false);
    }

    public void EndGame(bool won)
    {
        isPlaying = false;
        foreach (GameObject enemy in spawnedEnemies) Destroy(enemy);
        StopCoroutine("Second");
        StopCoroutine("SpawnEnemies");
        OpenEndScreen(won);
        GameManager.GM.FinishedGame(won);
    }

    public void OpenEndScreen(bool won)
    {
        if (won) endText.text = "YOU WON";
        else endText.text = "YOU LOST";
        endScreen.SetActive(true);
    }

    IEnumerator Second()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            if (sec > 0) sec--;
            timeText.text = sec.ToString("00");
            seconds--;
            float fill = (float)seconds / totalSeconds;
            loading.fillAmount = fill;
        }
    }
}
