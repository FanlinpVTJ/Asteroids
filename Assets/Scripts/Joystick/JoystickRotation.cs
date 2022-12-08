using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;


public class JoystickRotation : JoystickMain
{
    [SerializeField] private int rotateSpeed;

    public Quaternion RotateQuaternion;
    private float RotateFloat;
    Quaternion rotation;
    public bool joystickRotationActive;

    private void Update()
    {
        joystickRotationActive = !joysticActiveBool;
        
        if (inputVector.x !=0 || inputVector.y != 0)
        {
            var rotationInputJoystic = Mathf.Acos(inputVector.x) * 180 / Mathf.PI;
            if (inputVector.y > 0)
            {
                rotation = Quaternion.Euler(0, 0, rotationInputJoystic - 90);
            }
            if (inputVector.y < 0)
            {
                rotation = Quaternion.Euler(0, 0, -rotationInputJoystic - 90);
            }
            RotateQuaternion = rotation;
        }

        if (Input.GetAxis("Horizontal") != 0)
        {
            RotateFloat -= Input.GetAxis("Horizontal");
            RotateQuaternion = Quaternion.Euler(0, 0, RotateFloat * rotateSpeed);
        }
    }
}
