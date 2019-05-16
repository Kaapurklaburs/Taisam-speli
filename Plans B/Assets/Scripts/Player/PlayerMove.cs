using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Animator anime;
    public float WalkSeed;
    private float speed = 5f;
    public float RunSpeed;
    public Rigidbody rb;
    public float jumpForce;
    private float Aspeed;
    private bool hasJumped;
    public static float Damage = 0f;
    public float LastVelocity = 0f;
    private float velocity;


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        hasJumped = false;
        anime = GetComponentInChildren<Animator>();
    }

    void Update()
    {

        anime.SetFloat("MuSpeed", Aspeed, 0.1f, Time.deltaTime);
        float translation = Input.GetAxis("Vertical") * speed;
        float straffe = Input.GetAxis("Horizontal") * speed;
        translation *= Time.deltaTime;
        straffe *= Time.deltaTime;


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
        
        
        if (rb.velocity.y-LastVelocity > 10f)
        {
            Damage = 2f*( rb.velocity.y - LastVelocity);
        }   
        else
        {
            Damage = 0.0f;
        }
        LastVelocity = rb.velocity.y;
        //     if (Pause.IsPaused)
        //     {
        //         Cursor.lockState = CursorLockMode.None;
        //    }
        //     else
        //     {
        //         Cursor.lockState = CursorLockMode.Locked;
        //      }
        //  }

        velocity = rb.velocity.magnitude;
        if (Input.GetKey("r"))
        {
            speed = RunSpeed;
            Aspeed = translation * 10f;
        }
        else
        {
            Aspeed = translation * speed;
            if (Input.GetKey(KeyCode.LeftShift))
            {
                speed = WalkSeed / 3f;
            }
            else
            {
                speed = WalkSeed;
            }
        }
    }
}
