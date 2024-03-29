﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Granade : MonoBehaviour {

    public Transform zero;
    public float delay = 3f;
    public float BlastR = 5f;
    public float BlastF = 700f;
    bool hasExploded = false;
    public GameObject explosionEfect;
    float cowntDown;
    public float Dumage;

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

        Collider[] collidersDumage = Physics.OverlapSphere(transform.position, BlastR);
        foreach (Collider nearbyObject in collidersDumage)
        {

            HP dest = nearbyObject.GetComponent<HP>();
            if (dest != null)
            {
                HP.dumage = Dumage;
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

        Destroy(gameObject);
    }
}
