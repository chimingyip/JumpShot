using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndJump : MonoBehaviour
{
    public float power = 10f;
    public Rigidbody2D rb;

    [SerializeField] private Vector2 minPower;
    [SerializeField] private Vector2 maxPower;

    private Camera cam;
    private Vector2 force;
    private Vector3 startPoint;
    private Vector3 endPoint;
    private LineTrajectory tl;
    private bool isStill;

    private void Start()
    {
        cam = Camera.main;
        tl = GetComponent<LineTrajectory>();
    }

    private void Update() {
        if (rb.velocity == Vector2.zero) {
            isStill = true;
        } else {
            isStill = false;
        }

        if (Input.GetMouseButtonDown(0) && isStill == true) {
            startPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            startPoint.z = 15;
        }

        if (Input.GetMouseButton(0) && isStill == true) {
            Vector3 currentPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            currentPoint.z = 15;
            tl.RenderLine(startPoint, currentPoint);
        }

        if (Input.GetMouseButtonUp(0) && isStill == true) {
            endPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            endPoint.z = 15;

            force = new Vector2(Mathf.Clamp(startPoint.x - endPoint.x, minPower.x, maxPower.x), Mathf.Clamp(startPoint.y - endPoint.y, minPower.y, maxPower.y));
            rb.AddForce(force * power, ForceMode2D.Impulse);
            rb.gravityScale = 3.5f;
            tl.EndLine();
            if (startPoint.x - endPoint.x < 0) {
                transform.rotation = Quaternion.Euler(transform.rotation.x, 180, transform.rotation.z);
            } else {
                transform.rotation = Quaternion.Euler(transform.rotation.x, 0, transform.rotation.z);
            }
        }
    }
}
