using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallGrab : MonoBehaviour
{
    [Header("References")]
    public DragAndJump movement;
    public Transform orientation;
    public Transform cam;
    private Rigidbody2D rb;

    [Header("Wall Detection")]
    public float wallDetectionLength;
    public float wallCircleCastRadius;
    public LayerMask whatIsWall;

    private RaycastHit2D wallHit;
}
