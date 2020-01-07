using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    private float Horizontal;
    private float Vertical;
    private Rigidbody rigid;
    [SerializeField]
    private float speed = 10;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        /** Horrizontal Input value. Return 1 for right, -1 for left, and 0 if nothing*/
        Horizontal = Input.GetAxis("Horizontal");

        /**Vertical Input value. Return 1 for forward, -1 for backward, and 0 if nothing*/
        Vertical = Input.GetAxis("Vertical");

        Vector3 right = this.transform.right * Horizontal * speed;
        rigid.velocity = new Vector3(Mathf.Clamp(rigid.velocity.x + right.x, -speed, speed),
                                     rigid.velocity.y,
                                     Mathf.Clamp(rigid.velocity.z + right.z, -speed, speed));
        Vector3 forward = this.transform.forward * Vertical * speed;
        rigid.velocity = new Vector3(Mathf.Clamp(rigid.velocity.x + forward.x, -speed, speed),
                                     rigid.velocity.y,
                                     Mathf.Clamp(rigid.velocity.z + forward.z, -speed, speed));
        

        
    }
}
