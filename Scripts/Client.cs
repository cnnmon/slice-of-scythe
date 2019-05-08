using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[System.Serializable]
public class Client : ScriptableObject
{
    public string clientName = "";
    public TextAsset storyJSON;
    public Sprite sprite;
    public Sprite background;
    public string gameName; //name of scene of minigame
}