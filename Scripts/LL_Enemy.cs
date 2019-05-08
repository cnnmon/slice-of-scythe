using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LL_Enemy : MonoBehaviour
{
    LL_Manager manager;
    Rigidbody2D rb;
    //speed up speed later?

    private void Start()
    {
        manager = GameObject.Find("Manager").GetComponent<LL_Manager>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
        //constant movement
    {
        if (manager.isPlaying)
        {
            rb.velocity = new Vector2(-5, 0);
            if (name != "Ground" && transform.position.x < -15) Destroy(gameObject);
        }
    }
}
