using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    private Client client;
    public InkManager inkManager;

    [Header("GUI")]
    public SpriteRenderer clientImg;
    public SpriteRenderer clientBg;

    void Start()
    {
        inkManager.SwitchKnots(GameManager.GM.knotName);
        client = GameManager.GM.currentClient;
        UpdateUI();
    }

    private void UpdateUI()
    {
        clientImg.sprite = client.sprite;
        clientBg.sprite = client.background;
    }

} 
