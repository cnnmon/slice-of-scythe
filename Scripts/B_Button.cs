using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class B_Button : MonoBehaviour
{
    public Client client;

    public void GoToClient()
    {
        GameManager.GM.LoadUpClient(client);
    }
}
