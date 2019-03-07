using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {


    public float speed = 5f;
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

        if (Input.GetKey("space"))
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, Vector3.down, out hit, 1.01f))
            {
                if (hit.transform.position.y < transform.position.y)
                {
                    rb.AddForce(0, jumpForce, 0, ForceMode.Impulse);
                }
            }
        }


        if (Pause.IsPaused)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
        }



    }

}
