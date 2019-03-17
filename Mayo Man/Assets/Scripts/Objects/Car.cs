using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour {

    public HingeJoint weell1;
    public HingeJoint weell2;
    public HingeJoint weell3;
    public HingeJoint weell4;

    private bool inside;

    private void OnTriggerEnter(Collider other)
    {
        inside = true;
    }

    private void OnTriggerExit(Collider other)
    {
        inside = false;
    }

    // Use this for initialization
    void Start () {
        weell1.useMotor = false;
        weell2.useMotor = false;
        weell3.useMotor = false;
        weell4.useMotor = false;
    }
	
	// Update is called once per frame
	void Update () {
        weell1.useMotor = inside;
        weell2.useMotor = inside;
        weell3.useMotor = inside;
        weell4.useMotor = inside;
    }
}
