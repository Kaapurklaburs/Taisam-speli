using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GSpawn : MonoBehaviour {

    public string Spawn;
    bool HasSpawn = false;

    private void OnCollisionEnter(Collision collision)
    {

        if(HasSpawn == false)
        {
           if (collision.gameObject.isStatic)
           {
                ObjectPool.Instance.SpawnFromPool(Spawn, transform.position, Quaternion.identity);
                Destroy(gameObject);
           }
        }

    }

}
