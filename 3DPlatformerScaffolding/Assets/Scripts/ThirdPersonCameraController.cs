using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCameraController : MonoBehaviour
{
    /** changeable for different between target and player */
    public Transform Target,Player;

    // changeable rotation speed
    public float RotationSpeed = 1;

    // Private mouse axis (movement) for look calculation
    float mouseX, mouseY;

    // Start is called before the first frame update
    void Start()
    {
        //Turn off cursor and lock the mouse position
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //Call every frame after all functions in Update functions have been called 
        CamControl();
    }

    void CamControl()
    {
        //Chaning mouse X and y values
        mouseX += Input.GetAxis("Mouse X") * RotationSpeed;
        mouseY -= Input.GetAxis("Mouse Y") * RotationSpeed;
        mouseY = Mathf.Clamp(mouseY, -35, 60);

        //Look at the player
        transform.LookAt(Target);

        //Change the rotation of where the camera is looking and where the player is looking
        if (Input.GetKey(KeyCode.LeftControl))
        {
            //Looking mode not based on control if the player press left control (Can be changed)
            Target.rotation = Quaternion.Euler(mouseY, mouseX, 0);
        }
        else
        {
            Target.rotation = Quaternion.Euler(mouseY, mouseX, 0);
            //Update the actual player seen through the camera
            Player.rotation = Quaternion.Euler(0, mouseX, 0);
        }
        
    }


}