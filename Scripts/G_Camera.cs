using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G_Camera : MonoBehaviour
{
    public Camera cam;
    public Transform player;
    private float dampTime = 0.15f;
    private Vector3 velocity = Vector3.zero;

    private void Update()
    {
        if (player)
        {
            Vector3 point = cam.WorldToViewportPoint(player.position);
            Vector3 delta = player.position - cam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z));
            Vector3 destination = transform.position + delta;
            transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
        }
    }

}
