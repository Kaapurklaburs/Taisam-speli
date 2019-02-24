using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerThrow : MonoBehaviour {

    public float Force = 20f;
    public bool rObject = false;
    public GameObject Granade;

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            if(rObject)
            {
                GameObject granade = Instantiate(Granade, transform.position, transform.rotation);
                Rigidbody rb = granade.GetComponent<Rigidbody>();
                rb.AddForce(transform.forward * Force, ForceMode.Impulse);
            }
            else
            {
            GameObject granade = ObjectPool.Instance.SpawnFromPool("granade", transform.position, transform.rotation);
            Rigidbody rb = granade.GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * Force, ForceMode.Impulse);
            }
        }
    }
}
