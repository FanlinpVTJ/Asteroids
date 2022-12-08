
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class JoystickESC : MonoBehaviour
{
    private GameObject gameControllerObject;
    private SceneChanger gameController;

    private void Start()
    {
        gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
        gameController = gameControllerObject.GetComponent<SceneChanger>();
    }
    public void OnButtonClick()
    {
        Debug.Log("“ÛÚ");
        gameController.SceneChangerCoroutine(0, 0);
    }
}
