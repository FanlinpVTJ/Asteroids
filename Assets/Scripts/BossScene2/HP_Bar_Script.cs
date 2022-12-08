using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP_Bar_Script : MonoBehaviour
{
    [SerializeField] HealthSystem bossHealthSystem;
    [SerializeField] Image boss_HP_Bar;

    ObjectDestroyCoroutine BossExplosionCoroutine;
    
    private void Start()
    {
        BossExplosionCoroutine = GetComponent<ObjectDestroyCoroutine>();
    }

    private void Update()
    {
        boss_HP_Bar.fillAmount = (float)(bossHealthSystem.publicCurrentHealth) / (float)(bossHealthSystem.publicMaxHealth);
        if (bossHealthSystem.publicCurrentHealth <= 0)
        {
            BossDeath();
        }
    }
    
    private void BossDeath()
    {
        BossExplosionCoroutine.StartCoroutine(true, false);
    }
}
