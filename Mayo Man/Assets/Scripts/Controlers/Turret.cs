using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {

    public float Range = 10f;
    Transform target;
    public float delay = 3f;
    public String Bullet;
    float cowntDown;
    public Transform P;
    public float Force;

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, Range);
    }

    // Use this for initialization
    void Start () {
        target = PlayerManeger.instance.Player.transform;
        cowntDown = delay;
    }

    // Update is called once per frame
    void Update()
    {
        if (Pause.IsPaused)
        {
            return;
        }

        float distance = (target.position - transform.position).sqrMagnitude;
        cowntDown -= Time.deltaTime;
        if (distance <= Range * Range)
        {
        transform.LookAt(target);
            if (cowntDown <= 0f)
            {
                Fire();
                cowntDown = delay;
            }

        }
    }

    void Fire()
    {

        GameObject granade = ObjectPool.Instance.SpawnFromPool(Bullet, P.position, P.rotation);
        Rigidbody rb = granade.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * Force , ForceMode.Impulse);
    }
}
