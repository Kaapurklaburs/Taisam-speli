using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obsidian : MonoBehaviour
{

    public float D = 5f;
    Vector3 Foward;
    public float Speed;
    private float RealSpeed;
    public float l;

    void Start()
    {
        RealSpeed = Speed / 1000f;
        Foward = transform.forward * 1f + transform.position;
    }

    void Update()
    {
        Foward = transform.forward * 1f + transform.position;
        Vector3 Target = Vector3.Lerp(transform.position, Foward, RealSpeed);
        transform.position = Target;

        Destroy(gameObject, l);
    }
}

