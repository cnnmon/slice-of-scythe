using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class BalanceBehavior : MonoBehaviour
{
    [Header("GUI")]
    public TextMeshProUGUI cashText;
    public TextMeshProUGUI soulsText;

    private void Start()
    {
        UpdateUI();
    }

    public void UpdateUI()
    {
        cashText.text = GameManager.GM.money.ToString("$0.00");
        soulsText.text = GameManager.GM.souls.ToString("00");
    }

}
