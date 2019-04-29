using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveRagdoll : MonoBehaviour
{
    Vector3 Position;
    public float antiG;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Position = transform.position + new Vector3(0f, 1f, 0f);
        Vector3 posionS = Vector3.Lerp(transform.position, Position, antiG);
        transform.position = posionS;
    }
}
