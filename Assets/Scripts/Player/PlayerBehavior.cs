using System.Collections;
using System.Collections.Generic;
using TMPro.SpriteAssetUtilities;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerBehavior : MonoBehaviour
{
    [SerializeField] private Camera cam;
    private JoystickRotation joystickRotation;
    private JoystickMovement joystickMovement;
    private Rigidbody2D rb;
    private float screenWidth;
    private float screenHeight;

    public Vector2 move => joystickMovement.MoveVector2;
    public Quaternion rotate => joystickRotation.RotateQuaternion;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        transform.rotation = rotate;
        //rb.AddForce(transform.up * move.y * Time.deltaTime, ForceMode2D.Force);
        //rb.AddForce(transform.right * move.x * Time.deltaTime, ForceMode2D.Force);
        rb.AddForce(new Vector3(0, 1, 0) * move.y * Time.deltaTime, ForceMode2D.Force);
        rb.AddForce(new Vector3(1, 0, 0) * move.x * Time.deltaTime, ForceMode2D.Force);
    }

    private void OnBecameInvisible()
    {
        screenWidth = (1 / (cam.WorldToViewportPoint(new Vector3(1, 1)).x - 0.5f)) / 2;
        screenHeight = (1 / (cam.WorldToViewportPoint(new Vector3(1, 1)).y - 0.5f)) / 2;

        if (transform.position.x > screenWidth || transform.position.x < -screenWidth)
        {
            transform.position = new Vector3(-transform.position.x, transform.position.y, transform.position.z);
        }
        if (transform.position.y > screenHeight || transform.position.y < -screenHeight)
        {
            transform.position = new Vector3(transform.position.x, -transform.position.y, transform.position.z);
        }
    }
    public void Initialize(JoystickRotation joystickRotation, JoystickMovement joystickMovement)
    {
        this.joystickRotation = joystickRotation;
        this.joystickMovement = joystickMovement;
    }
}
