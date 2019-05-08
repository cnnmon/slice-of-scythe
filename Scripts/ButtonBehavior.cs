using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehavior : MonoBehaviour
{
    GameObject parent;

    private void Start()
    {
        Time.timeScale = 0;
        parent = gameObject.transform.parent.gameObject;
    }

    public void StartGame()
    {
        Time.timeScale = 1;
        parent.SetActive(false);
    }

}
