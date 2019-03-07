using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderControle : MonoBehaviour
{

    public float Range1 = 5f;
    public float Range2 = 6f;
    Vector3 Foward;


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
                    if (nearbyObject.gameObject.isStatic)
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
    
