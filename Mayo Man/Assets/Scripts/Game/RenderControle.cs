using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderControle : MonoBehaviour {

    public float Range1 = 5f;
    public float Range2 = 6f;

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, Range1);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, Range2);
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        Collider[] collidersMove = Physics.OverlapSphere(transform.position, Range2);
        foreach (Collider nearbyObject in collidersMove)
        {
            MeshRenderer ms = nearbyObject.GetComponent<MeshRenderer>();
            Transform tr = nearbyObject.GetComponent<Transform>();
            if (ms != null)
            {
                if ((tr.position - transform.position).sqrMagnitude <= Range1 * Range1)
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