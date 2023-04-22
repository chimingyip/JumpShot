using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    [SerializeField] private float bulletForce = 20f;
    private bool isFiring;

    [SerializeField] protected CooldownTimer fireDelayTimer;

    private void Awake() {
        fireDelayTimer = gameObject.AddComponent<CooldownTimer>();
    }

    private void FixedUpdate() {
        if (isFiring) {
            if (!fireDelayTimer.CooldownComplete) return;
            fireDelayTimer.StartCooldown();

            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
            bulletRb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        }
    }

    private void OnFire() {
        isFiring = !isFiring;
    }
}
