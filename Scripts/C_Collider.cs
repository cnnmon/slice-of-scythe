using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_Collider : MonoBehaviour
{
    private C_DragAndDrop script;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        script = collision.gameObject.GetComponent<C_DragAndDrop>();

        if (script != null)
        {
            if (script.collName == gameObject.name) script.inTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (script != null)
        {
            if (script.collName == gameObject.name) script.inTrigger = false;
        }
    }
}
