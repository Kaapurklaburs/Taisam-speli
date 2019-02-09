using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolSpawn : MonoBehaviour {

    public string Pool;

    private void FixedUpdate()
    {
        ObjectPool.Instance.SpawnFromPool( Pool , transform.position, Quaternion.identity);
    }
}
