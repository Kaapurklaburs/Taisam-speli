using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heel : MonoBehaviour {

    public float heeling = 30f;

    private void OnCollisionEnter(Collision collision)
    {
        HP heelabe = collision.transform.GetComponent<HP>();
        if (heelabe != null)
        {
            HP.heel = heeling;
            heelabe.Heel();
        }
        Destroy(gameObject);
    }

}
