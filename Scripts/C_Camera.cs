using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_Camera : MonoBehaviour
{
    public float speed = 15f;
    readonly float rangeX = 3f;
    readonly float rangeY = 2.4f;


    void Update()
    {
        Vector3 mousePosition = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 50f);

        if (mousePosition.x > -12f && mousePosition.x < 9.7f && mousePosition.y > -5f && mousePosition.y < 7f)
        {
            transform.position = Vector3.Lerp(transform.position, mousePosition, speed);
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, - rangeX, rangeX), Mathf.Clamp(transform.position.y, -rangeY, rangeY), -10f);
        }
    }
}
