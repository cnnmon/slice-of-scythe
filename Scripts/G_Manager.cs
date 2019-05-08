using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class G_Manager : MonoBehaviour
{
    private int totalTime; //total time needed to complete minigame
    readonly int timePerItem = 5; //seconds per item
    public string[] list = { };

    public bool playing = true;

    [HideInInspector]
    public string currentAisle; //idk
    private int listNum = -1;

    [Header("GUI")]
    public TextMeshProUGUI noteText;
    public GameObject spaceText;
    public GameObject endScreen;
    public Text endText;

    [Header("TIMER")]
    public Image loading;
    public TextMeshProUGUI timeText;
    private int sec;
    private int seconds = 0;
    private int totalSeconds = 0;

    private void Start()
    {
        UpdateList();

        //TIME//
        totalTime = list.Length * timePerItem;

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

    public void UpdateList()
    {
        listNum++;

        if (listNum < list.Length)
        {
            string item = list[listNum];

            noteText.text = item.Substring(1, item.Length - 1);
            currentAisle = item.Substring(0, 1);
        }
        else EndGame(true);
    }

    public void ShowSpaceText()
    {
        spaceText.SetActive(true);
    }

    public void HideSpaceText()
    {
        spaceText.SetActive(false);
    }

    public void EndGame(bool won)
    {
        playing = false;
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
