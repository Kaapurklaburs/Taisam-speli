using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

    public float dumage = 10f;
    public float Range = 100f;
    public float ImpactForce;
    public float FireRate = 15f;
    private float NextTimeToFire = 0f;
    public Camera FPScam;
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton("Fire1") && Time.time >= NextTimeToFire)
        {
            NextTimeToFire = Time.time + 1f / FireRate; 
            Shote();
        }
	}

    void Shote()
    {
        RaycastHit hit;
        if (Physics.Raycast(FPScam.transform.position, FPScam.transform.forward, out hit, Range))
        {

            HP dest = hit.transform.GetComponent<HP>();
            if (dest != null)
            {
                HP.dumage = dumage;
                dest.Dumage();
            }

            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * ImpactForce);
            }
        }
    }
}
