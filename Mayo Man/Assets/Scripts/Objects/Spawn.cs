using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public float delay = 3f;
    public GameObject TheObject;
    float cowntDown;
    private void Start()
    {
        cowntDown = delay;
    }

    void Update()
    {

        cowntDown -= Time.deltaTime;

            if (cowntDown <= 0f)
            {
                Spawne();
                cowntDown = delay;
            }


    }

    void Spawne()
    {
        Instantiate(TheObject, transform.position, transform.rotation);
    }

}
