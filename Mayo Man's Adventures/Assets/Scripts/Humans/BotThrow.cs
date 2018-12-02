using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotThrow : MonoBehaviour {

    public Transform player;
    public float delay = 3f;
    public GameObject Granade;
    float cowntDown;
    Vector3 off;
    private float ForceX;
    private float ForceZ;
    public float ForceY;
    Vector3 offset1;
    Vector3 offset2;

    // Use this for initialization
    void Start()
    {
        cowntDown = delay;
    }

    // Update is called once per frame
    void Update()
    {
        cowntDown -= Time.deltaTime;
        if (cowntDown <= 0f)
        {
            Explode();
            cowntDown = delay;
        }
    }

    void Explode()
    {
        off = player.position - transform.position;
        ForceX = off.x;
        ForceZ = off.z;

        if (ForceX >= 0)
        {
            offset1.x = 0.5f;
        }
        else
        {
            offset1.x = -0.5f;
        }

        if (ForceZ >= 0)
        {
            offset1.z = 0.5f;
        }
        else
        {
            offset1.z = -0.5f;
        }
        offset1.y = transform.position.y;

        offset2 = transform.position + offset1;

        GameObject granade = Instantiate(Granade, offset2, transform.rotation);
        Rigidbody rb = granade.GetComponent<Rigidbody>();
        rb.AddForce(ForceX, ForceY, ForceZ, ForceMode.Impulse);

    }
}
