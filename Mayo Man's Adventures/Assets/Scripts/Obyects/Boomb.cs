using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boomb : MonoBehaviour {

        public Transform zero;
    public float delay = 3f;
    public float BlastR = 5f;
    public float BlastF = 700f;
    bool hasExploded = false;
    public GameObject explosionEfect;
    float cowntDown;

    // Use this for initialization
    void Start()
    {
        cowntDown = delay;
    }

    // Update is called once per frame
    void Update()
    {
        cowntDown -= Time.deltaTime;
        if (cowntDown <= 0f && hasExploded == false)
        {
            Explode();
            hasExploded = true;
        }
    }

    void Explode()
    {
        Instantiate(explosionEfect, transform.position, zero.rotation);
        Collider[] colliders = Physics.OverlapSphere(transform.position, BlastR);
        foreach (Collider nearbyObject in colliders)
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
