using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G_Player : MonoBehaviour
{
    public G_Manager manager;
    public LL_Camera camManager;

    private Rigidbody2D rb;
    readonly float speed = 7.5f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 deltaPos = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        if(deltaPos != Vector2.zero && manager.playing)
        {
            rb.MovePosition(rb.position + deltaPos * speed * Time.deltaTime);
            transform.rotation = Quaternion.LookRotation(Vector3.forward, deltaPos);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        camManager.ShakeScreen(0.2f);
    }

}
