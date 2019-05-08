using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LL_Camera : MonoBehaviour
{
    public Camera cam;
    public Transform player;
    readonly float dampTime = 0.15f;
    private Vector3 velocity = Vector3.zero;

    readonly float screenShakeDecay = 2f;
    private Vector3 shakeOffset;
    public float shakeMultiplier = 0;

    private void Update()
    {
        if(shakeMultiplier > 0)
        {
            float x = Random.Range(-shakeMultiplier, shakeMultiplier);
            float y = Random.Range(-shakeMultiplier, shakeMultiplier);
            shakeOffset = new Vector3(x, y, 0f);
            shakeMultiplier -= Time.deltaTime * screenShakeDecay;
        }
        else
        {
            shakeOffset = Vector3.zero;
        }

        transform.position += shakeOffset;

        if (player !=null)
        {
            Vector3 point = cam.WorldToViewportPoint(player.position);
            Vector3 delta = player.position - cam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z));
            Vector3 destination = transform.position + delta;
            transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
        }
    }

    public void ShakeScreen(float multiplier)
    {
        shakeMultiplier = multiplier;
    }
}
