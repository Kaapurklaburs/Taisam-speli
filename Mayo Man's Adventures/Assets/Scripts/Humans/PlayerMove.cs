using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    public float speed = 10f;
    public Rigidbody rb;
    public float jumpForce;
    bool IsGrounded = true;

  
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

   // private void OnCollisionEnter(Collision collision)
  //  {
   //     if (collision.collider.tag == "Jumpable")
  //      {
  //          IsGrounded = true;
  //      }
  //      
  //  }
    private void OnCollisionExit(Collision collision)
    {
        IsGrounded = false;
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.tag == "Jumpable")
        {
            IsGrounded = true;
        }
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
        if(IsGrounded)
          {
           rb.AddForce(0, jumpForce, 0, ForceMode.Impulse);
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
