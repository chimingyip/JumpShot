using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallGrab : MonoBehaviour
{
    public bool wallGrab;

    private Rigidbody2D rb;
    private Collision collision;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        collision = GetComponent<Collision>();
    }

    private void Update()
    {
        //if (collision.onWall && Input.GetButton("Grab"))
        //{
        //    wallGrab = true;
        //}
        //if (!collision.onWall || Input.GetButtonUp("Grab"))
        //{
        //    wallGrab = false;
        //}
        if (wallGrab)
        {
            rb.gravityScale = 0;
            rb.velocity = new Vector2(rb.velocity.x, 0);
        }
    }
}
