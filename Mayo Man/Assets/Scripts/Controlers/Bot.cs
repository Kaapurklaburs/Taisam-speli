using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bot : MonoBehaviour {

    public float Range = 10f;
    Transform target;
    public Rigidbody Me;
    public float delay = 3f;
    public GameObject Granade;
    float cowntDown;
    Vector3 off;
    private float ForceX;
    private float ForceZ;
    public float ForceY;
    Vector3 offset1;
    Vector3 offset2;
    public float Speed;
    private float realSpeed;
    Vector3 tArget;
    public Transform Foward;

  //  Animator animater;


    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, Range);

    }

    // Use this for initialization
    void Start()
    {
        target = PlayerManeger.instance.Player.transform;
        cowntDown = delay;
        //  animater = GetComponentInChildren<Animator>();
        //  animater.SetFloat("Motion", value: 0.5f);
    }      
      

    // Update is called once per frame
    void Update()
    {

 

        if (Pause.IsPaused)
        {
            return;
        }

        tArget = new Vector3(Foward.position.x, 1f, Foward.position.z);
        realSpeed = Speed / 1000f;
        float distance = (target.position - transform.position).sqrMagnitude;
        off = target.position - transform.position;
        cowntDown -= Time.deltaTime;

        if (distance <= Range * Range)
        {
            if (cowntDown <= 0f)
            {
                Throw();

                cowntDown = delay;
            }
        //    else
        //    {
        //        animater.SetFloat("Motion", value: 0.5f);
        //    }
        }
        else
        {

            Move();
        }

        transform.LookAt(target);
    }

    void Throw()
    {
        //        animater.SetFloat("Motion", value: 1.5f);
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

    void Move()
    {

       // animater.SetFloat("Motion", value: 1f);
        Vector3 desiardP = tArget;
        Vector3 Target = Vector3.Lerp(transform.position, desiardP, realSpeed);
        transform.position = Target;
    }

}
