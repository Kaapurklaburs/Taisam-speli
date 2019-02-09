﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {

    public string Pool;

    private void FixedUpdate()
    {
        ObjectPooler.Instance.SpawnFromPool( Pool , transform.position, Quaternion.identity);
    }
}
