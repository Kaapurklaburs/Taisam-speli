using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EsterEggs : MonoBehaviour {

    public float time = 0.5f;

	
	// Update is called once per frame
	void LateUpdate () {
		if (Input.GetKey("t"))
        {
            Time.timeScale = time;
        }
        else
        {
            Time.timeScale = 1f;
        }
	}
}
