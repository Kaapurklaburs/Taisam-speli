﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderControle : MonoBehaviour
{

    public float Range1 = 5f;
    public float Range2 = 6f;
    Vector3 Foward;
    public Mesh cone;
    public Camera cam;
    public Vector3 coneScale;
    public float Range3 = 10f;
    float Range4 = 10.5f;


    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(Foward, Range1);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(Foward, Range2);
    }

    // Use this for initialization
    void Start()
    {
        Foward = transform.forward * (Range1 - 2f) + transform.position;
    }

    // Update is called once per frame
    void Update()
    {
  //      Cnt3();
        Cnt1();
    }

    void Cnt1()
    {
        Foward = transform.forward * (Range1 - 2f) + transform.position;
        Collider[] collidersMove = Physics.OverlapSphere(Foward, Range2);
        foreach (Collider nearbyObject in collidersMove)
        {
            MeshRenderer ms = nearbyObject.GetComponent<MeshRenderer>();
            Transform tr = nearbyObject.GetComponent<Transform>();
            if (ms != null)
            {
                if ((tr.position - Foward).sqrMagnitude <= Range1 * Range1)
                {
                    ms.enabled = true;
                }
                else
                {
                    if (nearbyObject.name == "Grounde")
                    {
                        ms.enabled = true;
                    }
                    else
                    {
                        ms.enabled = false;
                    }

                }

            }

            Cnt2();
        }
    }

    void Cnt2()
    {
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, Range1 * 5f))
        {
            MeshRenderer mhs = hit.collider.GetComponent<MeshRenderer>();
            if (mhs.enabled == false)
            {
                Collider[] collider = Physics.OverlapSphere(hit.transform.position, Range3);
                foreach (Collider nerbyObject in collider)
                {


                    MeshRenderer mesh = nerbyObject.GetComponent<MeshRenderer>();
                    Transform tra = nerbyObject.GetComponent<Transform>();
                    if (mesh != null)
                    {
                        mesh.enabled = true;
                    }
                }
            }
        }
    }

    void Cnt3()
    {
        Collider[] collidersMove = Physics.OverlapSphere(transform.position, Range4);
        foreach (Collider nearbyObject in collidersMove)
        {
            MeshRenderer ms = nearbyObject.GetComponent<MeshRenderer>();
            Transform tr = nearbyObject.GetComponent<Transform>();
            if (ms != null)
            {
                if ((tr.position - transform.position).sqrMagnitude <= Range3 * Range3)
                {
                    ms.enabled = true;
                }
                else
                {
                    if (nearbyObject.name == "Grounde")
                    {
                        ms.enabled = true;
                    }
                    else
                    {
                        ms.enabled = false;
                    }
                }
            }
        }
    }
}
    
