using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class I_Button : MonoBehaviour
{
    public Sprite[] frames;
    private int frameNum = 0;
    public SpriteRenderer sprite;

    private void Start()
    {
        Time.timeScale = 1;
    }

    public void NextButton()
    {
        if (frameNum + 1 < frames.Length)
        {
            frameNum++;
            sprite.sprite = frames[frameNum];
        } else
        {
            GameManager.GM.LoadScene("Bulletin");
        }
    }
}
