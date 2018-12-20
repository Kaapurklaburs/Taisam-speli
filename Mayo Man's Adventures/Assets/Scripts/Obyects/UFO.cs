using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFO : MonoBehaviour {

    public Transform player;
    public Rigidbody Me;
    public GameObject Granade;
    public float delay = 3f;
    float cowntDown;
    Vector3 offset;
    private Vector3 off;
    public Vector3 Soff;

    void Start()
    {
        cowntDown = delay;

    }
    // Update is called once per frame
    void Update()
    {
        off = player.position - transform.position;
        cowntDown -= Time.deltaTime;


        if (cowntDown <= 0f)
        {
            Spawn();
            cowntDown = delay;
        }



    }


    void Spawn()
    {
        offset = transform.position + Soff;

        GameObject granade = Instantiate(Granade, transform.position, transform.rotation);

    }
}
