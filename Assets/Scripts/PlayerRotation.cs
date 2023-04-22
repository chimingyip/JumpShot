using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    public float rotationOffset;

    private void FixedUpdate() {
        Vector3 mousePos = Input.mousePosition;
        Vector3 characterPos = Camera.main.WorldToScreenPoint(transform.position);

        mousePos.z = 0;
        mousePos.x = mousePos.x - characterPos.x;
        mousePos.y = mousePos.y - characterPos.y;

        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + rotationOffset));
    }
}
