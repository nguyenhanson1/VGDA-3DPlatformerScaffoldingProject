using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    // private variables for calulation of player movement
    private float Horizontal;
    private float Vertical;
    private Rigidbody rigid;

    //SerializeField make private variables editable in the inspector tab
    [SerializeField]
    private float speed = 10;
    [SerializeField]
    private float JumpForce = 1000;
    [SerializeField]
    private float groundCheck = 0.2f;
    [SerializeField]
    private Transform Legs;
    void Start()
    {
        //Get Rigidbody component of the gameobject to the private rigid variable 
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Call PlayerMovement first every change in frame
        PlayerMovement();   
    }
    void PlayerMovement()
    {
        /** Horrizontal Input value. Return 1 for right, -1 for left, and 0 if nothing*/
        Horizontal = Input.GetAxis("Horizontal");

        /** Vertical Input value. Return 1 for forward, -1 for backward, and 0 if nothing*/
        Vertical = Input.GetAxis("Vertical");

        /** Create Vector3 of change in player movement to calculate movement in player coordinates*/
        Vector3 playerMovement = new Vector3(Horizontal, 0f, Vertical) * speed * Time.deltaTime;
        transform.Translate(playerMovement, Space.Self);

        /** Check for input for space and if the player is close enough to the ground to jump */
        if (Input.GetKeyDown(KeyCode.Space) && Physics.Raycast(Legs.position, transform.up * -1, groundCheck))
        {
            /** Add force to rigidbody to go up */
            rigid.AddForce(Vector3.up * JumpForce);
        }
    }
}
