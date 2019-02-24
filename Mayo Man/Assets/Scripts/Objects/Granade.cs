using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Granade : MonoBehaviour {

    public Transform zero;
    public float delay = 3f;
    public float BlastR = 5f;
    public float BlastF = 700f;
    bool hasExploded = false;
    public GameObject explosionEfect;
    float countDown;
    public float Dumage0;
    private float Dumage1;
    private float P;

    // Use this for initialization
    void Start()
    {
        countDown = delay;
    }

    // Update is called once per frame
    void Update()
    {
        countDown -= Time.deltaTime;
        if (countDown <= 0f && hasExploded == false)
        {
            Explode();
            hasExploded = true;
        }
    }

    void Explode()
    {
        Instantiate(explosionEfect, transform.position, zero.rotation);

        Collider[] collidersDumage = Physics.OverlapSphere(transform.position, BlastR);
        foreach (Collider nearbyObject in collidersDumage)
        {

            HP dest = nearbyObject.GetComponent<HP>();
            Transform tr = nearbyObject.GetComponent<Transform>();
            if (dest != null)
            {
                P =  (tr.position - transform.position).sqrMagnitude;
                Dumage1 = BlastR * BlastR * Dumage0 / P;
                HP.dumage = Dumage1;
                dest.Dumage();
            }

        }

        Collider[] collidersMove = Physics.OverlapSphere(transform.position, BlastR);
        foreach (Collider nearbyObject in collidersMove)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(BlastF, transform.position, BlastR);
            }
        }

        gameObject.SetActive(false);
        hasExploded = false;
    }
}
