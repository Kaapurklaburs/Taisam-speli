using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour {

    public Transform receiver;
    Transform player;
    Vector3 Offset;
    private bool InTeleport = false;
    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            InTeleport = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            InTeleport = true;
        }
    }

	void Start () {
        player = PlayerManeger.instance.Player.transform;
    }
	
	// Update is called once per frame
	void Update () {

        Offset = player.position - transform.position;


        if (InTeleport)
        {
            player.position = receiver.position + Offset;
        }
	}







}
