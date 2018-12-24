using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFO : MonoBehaviour {

    public Transform player;
    public Rigidbody Me;
    public GameObject Granade;
    public float delay = 0.1f;
    float cowntDown;
    Vector3 offset;
    private Vector3 off;
    public Vector3 Soff;
    private bool faund = false;

    void Start()
    {
        cowntDown = delay;

    }
    // Update is called once per frame
    void Update()
    {
        off = player.position - transform.position;
        cowntDown -= Time.deltaTime;

        if (faund)
        {
           if (cowntDown <= 0f)
           {
               Spawn();
               cowntDown = delay;
           }
        }
        else
        {
            Find();
        }




    }


    void Spawn()
    {
        offset = transform.position + Soff;

        GameObject granade = Instantiate(Granade, transform.position, transform.rotation);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == ("Player"))
        {
            faund = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == ("Player"))
        {
            faund = false;
        }
    }

    void Find()
    {
        Me.AddForce(off.x * 3f, 0f, off.z * 3f, ForceMode.Force);

    }
}
