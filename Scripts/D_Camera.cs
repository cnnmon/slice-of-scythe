using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class D_Camera : MonoBehaviour
{
    public float speed = 0.3f;
    private float rotX;
    private float rotY;

    readonly float xRange = 5f;
    readonly float yRange = 10f;

    private Camera cam;

    private void Start()
    {
        cam = GetComponent<Camera>();
    }

    void Update()
    {
        rotX += Input.GetAxis("Mouse X") * speed;
        rotY += Input.GetAxis("Mouse Y") * speed;

        rotX = Mathf.Clamp(rotX, -xRange, xRange);
        rotY = Mathf.Clamp(rotY, -yRange, yRange);

        transform.rotation = Quaternion.Euler(-rotY, 0f, 0f);
        transform.rotation = Quaternion.Euler(0f, rotX, 0f);
    }
}
