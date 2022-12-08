
using UnityEngine;

public class ButtonFireScript : MonoBehaviour
{
    private PlayerLaserShot playerLaserShot;
    private JoystickRotation joystickRotation;
    
    private void Update()
    {
        if (joystickRotation.joystickRotationActive)
        playerLaserShot.LaserShot();
    }
    
    public void Initialize(PlayerLaserShot playerLaserShot, JoystickRotation joystickRotation)
    {
        this.playerLaserShot = playerLaserShot;
        this.joystickRotation = joystickRotation;
    }
   
}
