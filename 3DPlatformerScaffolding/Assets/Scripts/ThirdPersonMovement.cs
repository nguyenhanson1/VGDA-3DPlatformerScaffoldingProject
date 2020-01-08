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
        PlayerMovement();

        
    }
    void PlayerMovement()
    {
        /** Horrizontal Input value. Return 1 for right, -1 for left, and 0 if nothing*/
        Horizontal = Input.GetAxis("Horizontal");

        /**Vertical Input value. Return 1 for forward, -1 for backward, and 0 if nothing*/
        Vertical = Input.GetAxis("Vertical");

        Vector3 playerMovement = new Vector3(Horizontal, 0f, Vertical) * speed * Time.deltaTime;
        transform.Translate(playerMovement, Space.Self);

    }
}
