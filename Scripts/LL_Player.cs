using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LL_Player : MonoBehaviour
{
    public LL_Manager manager;
    public LL_Camera camManager;

    private Rigidbody2D rb;
    private Animator anim;

    private float force;

    readonly float initForce = 555f;
    //readonly float duckForce = 400f;
    readonly float heightThresh = 2f;

    private void Start()
    {
        force = initForce;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        //jump controls
        if (Input.GetKeyDown(KeyCode.UpArrow) && !InAir() && manager.isPlaying)
        {
            rb.AddForce(Vector2.up * force);
        }
    }

    private bool InAir()
    {
        if (transform.position.y > heightThresh) return true;
        else return false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            manager.UpdateLives();
            Destroy(collision.gameObject);
            camManager.ShakeScreen(0.4f);

        }
    }

}
