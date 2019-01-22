using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forcer : MonoBehaviour {

    public Rigidbody rb;
    Transform player;
    private bool tuched = false;
    public float recharge = 30f;
    float countdown;
    public float Force = 1000f;
    private Vector3 Offset;




	// Use this for initialization
	void Start () {
        player = PlayerManeger.instance.Player.transform;
    }
	
	// Update is called once per frame
	void Update () {
        countdown -= Time.deltaTime;
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
