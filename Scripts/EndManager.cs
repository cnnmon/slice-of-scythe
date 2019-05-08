using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EndManager : MonoBehaviour
{
    public Sprite winImg;
    public Sprite loseImg;
    public Image image;

    public TextMeshProUGUI endText;

    void Start()
    {
        if (GameManager.GM.won)
        {
            image.sprite = winImg;
            endText.text = "Congrats! You got the hat of your dreams.";
        }
        else
        {
            image.sprite = loseImg;
            endText.text = "You'll get 'em next time.";
        }
    }

    public void RestartButton()
    {
        GameManager.GM.RestartGame();
    }
}
