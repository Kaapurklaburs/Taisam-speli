using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dead : MonoBehaviour {

    public Rigidbody BodyPart;
    public float Force;

	// Use this for initialization
	void Start () {
        BodyPart.AddForce(transform.forward * Force, ForceMode.Impulse);

    }

}
