using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class G_Bubble : MonoBehaviour
{
    public G_Manager manager;
    private SpriteRenderer rend;

    public Sprite hiddenImg;
    public Sprite realImg;
    private GameObject circleImg;

    private bool inTrigger;

    private void Start()
    {
        circleImg = transform.GetChild(0).gameObject;
        circleImg.SetActive(false);

        rend = GetComponent<SpriteRenderer>();
        rend.sprite = hiddenImg;
        rend.color = new Color(1, 1, 1, 0.5f);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && inTrigger)
        {
            manager.UpdateList();
            UpdateIndicator(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        rend.sprite = realImg;
        rend.color = new Color(1, 1, 1, 1f);

        //if needed aisle matches up to the one player is in
        if (manager.currentAisle == name) UpdateIndicator(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        rend.color = new Color(1, 1, 1, 0.5f);
        rend.sprite = hiddenImg;

        if (manager.currentAisle == name) UpdateIndicator(false);
    }

    private void UpdateIndicator(bool i)
    {
        if (i) manager.ShowSpaceText();
        else manager.HideSpaceText();

        circleImg.SetActive(i);
        inTrigger = i;
    }
}
