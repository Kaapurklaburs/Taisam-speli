using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerThrow : MonoBehaviour {

    public float Force = 20f;
    public GameObject Granade;
   // public Vector3 offset;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject granade = Instantiate(Granade, transform.position, transform.rotation);
            Rigidbody rb = granade.GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * Force,ForceMode.Impulse);
        }
    }
}
