using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;


public class EventOnDestroy : MonoBehaviour
{
    public event Action OnDestroyObject;

    public void OnDestroy()
    {
        Debug.Log(Equals(gameObject.name) + "уничтожен");
        OnDestroyObject();
        if (OnDestroyObject != null)
        {
            //OnDestroyObject();
            Debug.Log("Эвент сработать должен");
        }
            
        
    }
}
