﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End : MonoBehaviour {

    // public GameObject explosionEfect;
    public float LifeTime = 2f;


    void Start()
    {

    }

    void Update()
    {
        Destroy(gameObject, LifeTime);
    }
}
