using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float LockOnTime = 4;
    public float horizontalSpeed = 2.0f;
    public float verticalSpeed = 2.0f;
    private bool Changing = false;
    private float waitTimer;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        if(Input.GetAxis("Mouse X") == 0 && Input.GetAxis("Mouse Y") == 0)
        {
            if (waitTimer > 0)
            {
                waitTimer -= Time.deltaTime;
            }
            if (waitTimer <= 0)
            {
                Changing = false;
            }

        }
        else
        {
            Changing = false;
            waitTimer = LockOnTime;
        }

        if (Changing)
        {
            // Get the mouse delta. This is not in the range -1...1
            float h = horizontalSpeed * Input.GetAxis("Mouse X");
            transform.RotateAroundLocal(target.transform.position, h);
        }else{
            this.transform.position = target.transform.position;
            this.transform.rotation = Quaternion.LookRotation(target.forward);
        }
        
    }

    
}
