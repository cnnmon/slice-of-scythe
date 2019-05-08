using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class C_Manager : MonoBehaviour
{
    private int totalTime; //total time needed to complete minigame
    readonly int timePerItem = 6; //time needed for each item - calculates total time

    private int itemsTotal;
    private int itemsCleaned = 0;
    public Transform objectParent;

    [Header("GUI")]
    public Slider slider;
    public GameObject endScreen;
    public Text endText;

    [Header("TIMER")]
    public Image loading;
    public TextMeshProUGUI timeText;
    private int sec;
    private int seconds = 0;
    private int totalSeconds = 0;

    void Start()
    {
        itemsTotal = objectParent.childCount;
        totalTime = itemsTotal * timePerItem;

        //TIMER//
        sec = totalTime;
        timeText.text = sec.ToString("00");
        if (sec > 0) seconds += sec;
        totalSeconds = seconds;
        StartCoroutine("Second");
    }

    private void Update()
    {
        if (sec == 0) EndGame(false);
    }

    public void UpdateCleanliness()
        //called from drag and drop when inTrigger
    {
        itemsCleaned++;
        slider.value = (float)itemsCleaned / (float)itemsTotal;
        
        if (itemsCleaned == itemsTotal) EndGame(true);
    }

    public void EndGame(bool won)
    {
        StopCoroutine("Second");
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
