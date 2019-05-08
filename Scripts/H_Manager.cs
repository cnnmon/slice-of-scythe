using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class H_Manager : MonoBehaviour
{
    readonly int totalTime = 60; //total time needed to complete minigame
    public int lives = 4;
    public H_Shake camManager;
    public GameObject hint;

    [Header("GUI")]
    public TMP_InputField appleInput;
    public TMP_InputField bananaInput;
    public TMP_InputField coconutInput;
    public TMP_InputField totalInput;
    public TextMeshProUGUI livesText;

    [Header("TIMER")]
    public Image loading;
    public TextMeshProUGUI timeText;
    private int sec;
    private int seconds = 0;
    private int totalSeconds = 0;

    private void Start()
    {
        lives--;
        string livesString = "";
        for (int i = 0; i < lives; i++) livesString += "x";
        livesText.text = livesString;

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

    private void UpdateLives()
    {
        lives--;
        hint.SetActive(true);
        string livesString = "";
        for (int i = 0; i < lives; i++) livesString += "x";
        livesText.text = livesString;
        camManager.ShakeScreen(0.4f);
    }

    public void SubmitButton()
    {
        if (CheckAnswer()) EndGame(true);
        else
        {
            if (lives - 1 > 0) UpdateLives();
            else EndGame(false);
        }
    }

    private bool CheckAnswer()
    {
        int apple = -1;
        int banana = -1;
        int coconut = -1;
        int total = -1;

        if(appleInput.text != "") apple = int.Parse(appleInput.text);
        if(bananaInput.text != "") banana = int.Parse(bananaInput.text);
        if(coconutInput.text != "") coconut = int.Parse(coconutInput.text);
        if(totalInput.text != "") total = int.Parse(totalInput.text);

        if (apple == 10 && banana == 1 && coconut == 2 && total == 15) return true;
        else return false;
    }

    public void EndGame(bool won)
    {
        StopCoroutine("Second");
        GameManager.GM.FinishedGame(won);
        GameManager.GM.LoadScene("Dialogue");
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
