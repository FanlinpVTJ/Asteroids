using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TEXT_BossHP : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI bossHP;
    HealthSystem healthSystem;

    // Start is called before the first frame update
    void Start()
    {
        healthSystem = GetComponent<HealthSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        bossHP.text = $"{healthSystem.publicCurrentHealth} / {healthSystem.publicMaxHealth}";
    }
}
