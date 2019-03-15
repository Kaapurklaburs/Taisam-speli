using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {


    public float speed = 5f;
    public Rigidbody rb;
    public float jumpForce;
    private float ShiftSpeed;


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        ShiftSpeed = speed / 2f;
    }

    private void OnCollisionEnter(Collision collision)
    {


    }


    void Update()
    {
        float translation = Input.GetAxis("Vertical") * speed;
        float straffe = Input.GetAxis("Horizontal") * speed;
        translation *= Time.deltaTime;
        straffe *= Time.deltaTime;
        if (Input.GetKey (KeyCode.LeftShift))
        {
            rb.MovePosition(transform.position + (transform.forward * translation /2f) + (transform.right * straffe / 2f));
        }
        else
        {
        rb.MovePosition(transform.position + (transform.forward * translation) + (transform.right * straffe));
        }

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
