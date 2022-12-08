using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidsBehavior : MonoBehaviour
{
    [SerializeField]
    private int asteroidsSpeed;

    [SerializeField] 
    private Transform target;

    private void OnBecameVisible()
    {
        transform.LookAt(target.transform);
       // GetComponent<Rigidbody2D>().AddForce(transform.forward * asteroidsSpeed, ForceMode2D.Impulse);
    }
    private void OnBecameInvisible()
    {
        //Destroy(gameObject);
    }
}
