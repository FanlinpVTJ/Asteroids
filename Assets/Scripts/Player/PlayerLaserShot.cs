using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class PlayerLaserShot : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private float laserReloadCooldawn;

    private float time = 0f;
 
    public void LaserShot()
    {
        if(time == 0)
        {
            Instantiate(bullet, gameObject.transform.position, gameObject.transform.rotation);
            time = laserReloadCooldawn;
        }
       
    }
    private void Update()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
            if (time <= 0)
            {
                time = 0;
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            LaserShot();
        }
    }
    
}
