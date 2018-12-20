using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {

    private void FixedUpdate()
    {
        ObjectPooler.Instance.SpawnFromPool("Mayo", transform.position, Quaternion.identity);
    }
}
