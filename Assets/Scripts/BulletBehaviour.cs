using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    [SerializeField] private int damage;

    private void OnTriggerEnter2D(Collider2D collision) {

        Damage damageableGameObject = collision.GetComponent<Damage>();

        if (damageableGameObject) {
            damageableGameObject.TakeDamage(damage);
        }

        Destroy(gameObject);
    }
}
