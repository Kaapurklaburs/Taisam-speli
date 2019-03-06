using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explozija : MonoBehaviour
{

    public float BlastR = 5f;
    public float BlastF = 700f;
    bool hasExploded = false;

    private void OnCollisionEnter(Collision collision)
    {
        if ( hasExploded == false)
        {
            Explode();
            hasExploded = true;
        }        
    }


    void Explode()
    {

        Collider[] collidersMove = Physics.OverlapSphere(transform.position, BlastR);
        foreach (Collider nearbyObject in collidersMove)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(BlastF, transform.position, BlastR);
            }
        }

        Destroy(gameObject);
    }
}

