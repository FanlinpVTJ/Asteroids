using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    [SerializeField] 
    private int bulletSpeed;
    [SerializeField]
    private int bulletDamage;


    private void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(transform.up * bulletSpeed, ForceMode2D.Impulse);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        var healthSystem = collision.gameObject.GetComponent<HealthSystem>();

        if (collision.tag == "Enemy")
        {
            Destroy(gameObject);            
        }
        if (healthSystem != null)
        {
            healthSystem.TakeDamage(bulletDamage);
        }
    }
}
