using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRotation : MonoBehaviour
{
    [SerializeField] int rotationSpeed;
    float angleBossRotation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        angleBossRotation += Time.deltaTime;
        transform.rotation = Quaternion.Euler(0f, 0f, rotationSpeed * angleBossRotation);
    }
}
