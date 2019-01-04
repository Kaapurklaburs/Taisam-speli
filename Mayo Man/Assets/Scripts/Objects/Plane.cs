using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour {

    Transform target;
    public float Speed = 0.1f;
    private float realSpeed;
    public float delay = 0.5f;
    public GameObject Granade;
    float cowntDown;
    public Vector3 offset;

    void Start()
    {
        target = PlayerManeger.instance.Player.transform;

    }

    // Update is called once per frame
    void Update()
    {
        realSpeed = Speed / 1000f;
        cowntDown -= Time.deltaTime;

            if (cowntDown <= 0f)
            {
                Bomb();
                cowntDown = delay;
            }
        Vector3 desiardP = target.position + offset;
        Vector3 Target = Vector3.Lerp(transform.position, desiardP, realSpeed);
        transform.position = Target;


	}

    void Bomb()
    {
     Instantiate(Granade, transform.position, transform.rotation);
    }
}