using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager GM;

    //VARIABLES//
    public int money = 0;
    public int souls = 0;

    public List<Client> clients = new List<Client>();
    public Client currentClient;
    public string knotName;
    public bool wonGame;

    public GameObject transition;
    public string sceneToLoad;

    public bool won; //entire game

    private void Awake()
    {
        Time.timeScale = 1;
        JustMonika();
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        knotName = "start";
    }

    private void JustMonika()
    {
        if (GM == null) GM = this;
        else if (GM != this) Destroy(gameObject);
    }

    public void FinishedGame(bool won)
        //called when game is finished to get correct dialogue up
    {
        wonGame = won;
        if (won) knotName = "won";
        else knotName = "lost";
    }

    public void UpdateMoney(int newMoney)
    {
        money += newMoney;
    }

    public void UpdateSouls(int newSouls)
    {
        souls += newSouls;
    }

    //BUTTONS//
    public void LoadUpClient(Client client)
    {
        knotName = "start";
        currentClient = client;
        LoadScene("Dialogue");
    }

    //TRANSITION//
    public void LoadScene(string sceneName)
    {
        transition = GameObject.Find("Transition");
        sceneToLoad = sceneName;
        transition.GetComponent<Animator>().SetTrigger("close");

    }

    public void CalledRestart()
    {
        SceneManager.LoadScene(sceneToLoad);
        transition.GetComponent<Animator>().SetTrigger("open");
    }

    //CHECK IF END//
    public bool StillPlaying()
    {
        if (clients.Count < 4) return true;
        else return false;
    }

    public bool IfDone(Client client)
    {
        if (clients.Contains(client)) return true;
        else return false;
    }

    public void EndGame()
    {
        if (money >= 40 && souls == 4) won = true;
        else won = false;
        LoadScene("End");
    }
    
    //RESTART//
    public void RestartGame()
    {
        money = 0;
        souls = 0;
        clients.RemoveRange(0, clients.Count);
        LoadScene("Intro");
    }
}