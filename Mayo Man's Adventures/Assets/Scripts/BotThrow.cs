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
        GameObject granade = Instantiate(Granade, transform.position, transform.rotation);
        Rigidbody rb = granade.GetComponent<Rigidbody>();
        rb.AddForce(ForceX, ForceY, ForceZ, ForceMode.Impulse);

    }
}
