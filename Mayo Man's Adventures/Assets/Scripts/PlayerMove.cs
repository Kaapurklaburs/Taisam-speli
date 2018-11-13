using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    public float speed = 10f;
    public Rigidbody rb;
    public float jumpForce;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }




    void Update()
    {



        float translation = Input.GetAxis("Vertical") * speed;
        float straffe = Input.GetAxis("Horizontal") * speed;
        translation *= Time.deltaTime;
        straffe *= Time.deltaTime;

        transform.Translate(straffe, 0, translation);

        if (Input.GetKeyDown("space"))
        {
            rb.AddForce(0, jumpForce, 0, ForceMode.Impulse);
        }

        if (Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.None;
        }


    }
}
