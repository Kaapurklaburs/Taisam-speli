using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forcer : MonoBehaviour {

    public Rigidbody rb;
    Transform player;
    public float recharge = 30f;
    public float Force = 1000f;
    private Vector3 Offset;




	// Use this for initialization
	void Start () {
        player = PlayerManeger.instance.Player.transform;
    }
	
	// Update is called once per frame
	void Update ()
    {

        Offset = player.position - transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Player")
        {
            rb.AddForce(Offset.x * Force, Offset.y ,Offset.z * Force, ForceMode.Impulse);
        }
    }
}
