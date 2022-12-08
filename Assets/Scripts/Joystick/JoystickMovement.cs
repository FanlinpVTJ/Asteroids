using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;


public class JoystickMovement : JoystickMain
{
    [SerializeField] private int moveSpeed;
    public Vector2 MoveVector2;

    private void Update()
    {
        if (inputVector.x != 0 || inputVector.y != 0)
        {
            MoveVector2 = new Vector2(inputVector.x * moveSpeed * inputVector.magnitude, inputVector.y* moveSpeed * inputVector.magnitude);
        }
        
        if (Input.GetAxis("Vertical") != 0)
        {
            MoveVector2 = new Vector2(moveSpeed * Input.GetAxis("Vertical"), 0);
        }
        
        if (inputVector.magnitude == 0 && Input.GetAxis("Vertical")==0) MoveVector2 = Vector2.zero;
    }
    
}
