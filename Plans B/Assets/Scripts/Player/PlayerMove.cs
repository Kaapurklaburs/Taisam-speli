﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public float speed = 5f;
    public Rigidbody rb;
    public float jumpForce;
    private bool hasJumped;
    public PlayerStats ps;



    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        hasJumped = false;
    }

    void Update()
    {
        float translation = Input.GetAxis("Vertical") * speed;
        float straffe = Input.GetAxis("Horizontal") * speed;
        translation *= Time.deltaTime;
        straffe *= Time.deltaTime;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            rb.MovePosition(transform.position + (transform.forward * translation / 3f) + (transform.right * straffe / 3f));
        }
        else
        {
            rb.MovePosition(transform.position + (transform.forward * translation) + (transform.right * straffe));

            if (Input.GetKey("space") && hasJumped == false)
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, Vector3.down, out hit, 1.01f))
                {
                    if (hit.transform.position.y < transform.position.y)
                    {
                        rb.AddForce(0, jumpForce, 0, ForceMode.Impulse);
                        hasJumped = true;
                    }
                }
            }
            else
            {
                hasJumped = false;
            }
        }
        if (rb.velocity.y > 10f)
        {
            PlayerStats.PlayerSts.Damage(0.01f);
        }

        //     if (Pause.IsPaused)
        //     {
        //         Cursor.lockState = CursorLockMode.None;
        //    }
        //     else
        //     {
        //         Cursor.lockState = CursorLockMode.Locked;
        //      }
        //  }
    }
}
