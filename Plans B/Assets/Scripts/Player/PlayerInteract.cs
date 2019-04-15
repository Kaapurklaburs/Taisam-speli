using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private bool hasGrabd = false;
    public Transform Vieta;
    private Rigidbody rb;
    GameObject Player;
    public float GrabSpeed = 0.1f;
    public float Range = 1.5f;

    void Start()
    {
        Player = this.transform.parent.gameObject;
    }

    private void FixedUpdate()
    {
       if (Input.GetButton("Fire1"))
       {
          if (!hasGrabd)
          {
              RaycastHit hit;
              if (Physics.Raycast(transform.position, transform.forward, out hit, Range))
              {
                  rb = hit.transform.GetComponent<Rigidbody>();
                  if(rb != null)
                  {
                      Vieta.position = rb.position;
                      rb.useGravity = false;
                      hasGrabd = true; 
                  }
     
              }
          }
       }
       if (Input.GetButton("Fire2"))
       {
            hasGrabd = false;
            rb.rotation = Player.transform.rotation;
            rb.useGravity = true;
       }

       if (hasGrabd)
       {
            Vector3 SmothPosition = Vector3.Lerp(rb.position, Vieta.position, GrabSpeed);
            rb.position = SmothPosition;
            rb.rotation = Player.transform.rotation;
       }
    }
}


