using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End : MonoBehaviour {

    public float LifeTime = 2f;
    public bool OneTime = false;
    float countDown;


    void Start()
    {
        countDown = LifeTime;
    }

    void Update()
    {

        countDown -= Time.deltaTime;
        if (OneTime)
        {
        Destroy(gameObject, LifeTime);
        }
        else
        {
            if(countDown <= 0f)
            {
            gameObject.SetActive(false);
            }

        }

    }
}
