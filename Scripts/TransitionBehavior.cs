using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransitionBehavior : MonoBehaviour
{
    public bool invis;

    private void Start()
    {
        if (invis) GetComponent<Image>().color = new Color(1, 1, 1, 0);
        else GetComponent<Image>().color = new Color(1, 1, 1, 1);
    }

    public void CallRestart()
    //function called once in-transition is done
    {
        GameManager.GM.CalledRestart();
    }
}
