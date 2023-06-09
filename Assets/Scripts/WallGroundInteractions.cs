using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallGroundInteractions : MonoBehaviour
{
    [Header("Player")]
    public Rigidbody2D rb;

    [Header("Grounded")]
    public Transform groundCheck;
    public float groundRadius = 0.2f;
    private bool isGrounded = false;
    [SerializeField] private LayerMask groundLayer;

    [Header("WallGrab")]
    public float wallDistance = 0.6f;
    private bool isWallGrabbing = false;
    private RaycastHit2D wallCheckHit;
    private bool onRightWall = false;
    [SerializeField] private LayerMask wallLayer;

    private bool isFacingRight = true;
    private float horizontalDirection;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        horizontalDirection = rb.velocity.x;
    }

    private void FixedUpdate()
    {
        bool touchingGround = Physics2D.OverlapCircle(groundCheck.position, groundRadius, groundLayer);
        onRightWall = Physics2D.Raycast(transform.position, new Vector2(wallDistance, 0), wallDistance, wallLayer);

        isFacingRight = transform.rotation.y >= 0;

        if (touchingGround) {
            isGrounded = true;
        } else {
            isGrounded = false;
        }

        if (isFacingRight) {
            wallCheckHit = Physics2D.Raycast(transform.position, new Vector2(wallDistance, 0), wallDistance, wallLayer);
        } else {
            wallCheckHit = Physics2D.Raycast(transform.position, new Vector2(-wallDistance, 0), wallDistance, wallLayer);
        }

        if (wallCheckHit && !isGrounded) {
            isWallGrabbing = true;
            StickToWall();
        } else {
            isWallGrabbing = false;
        }

        if (isWallGrabbing) {
            rb.velocity = Vector2.zero;
            rb.gravityScale = 0f;
        }
    }

    private void StickToWall() {
        //Push player torwards wall
        if (onRightWall && horizontalDirection >= 0f) {
            rb.velocity = new Vector2(1f, rb.velocity.y);
        } else if (!onRightWall && horizontalDirection <= 0f) {
            rb.velocity = new Vector2(-1f, rb.velocity.y);
        }
    }
}
