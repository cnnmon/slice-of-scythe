using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletinManager : MonoBehaviour
{
    public B_Button[] buttons;

    // Start is called before the first frame update
    void Start()
    {
        UpdateUI();
    }

    private void UpdateUI()
    {
        foreach (B_Button button in buttons)
        //loops through all buttons to check if the client is done
        {
            if (GameManager.GM.IfDone(button.client)) button.gameObject.SetActive(false);
        }

        if (!GameManager.GM.StillPlaying()) GameManager.GM.EndGame();
    }
}
