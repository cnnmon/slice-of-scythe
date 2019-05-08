using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class H_Shake : MonoBehaviour
{
    readonly float screenShakeDecay = 2f;
    private Vector3 shakeOffset;
    public float shakeMultiplier = 0;
    private float dampTime = 0.15f;
    private Vector3 velocity = Vector3.zero;

    private Vector2 initPos;

    private void Start()
    {
        initPos = transform.position;
    }

    private void Update()
    {
        if (shakeMultiplier > 0)
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
        transform.position = Vector3.SmoothDamp(transform.position, initPos, ref velocity, dampTime);
    }

    public void ShakeScreen(float multiplier)
    {
        shakeMultiplier = multiplier;
    }
}
