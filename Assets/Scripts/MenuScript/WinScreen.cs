using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScreen : MonoBehaviour
{
    [SerializeField]
    SceneChanger sceneChanger;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            StartCoroutine(sceneChanger.SceneChangerCoroutine(0, 0));
        }
    }
}
