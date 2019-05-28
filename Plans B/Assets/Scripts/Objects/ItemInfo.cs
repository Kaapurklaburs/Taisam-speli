using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInfo : MonoBehaviour
{
    [SerializeField]
    public Structs.Item Item;
    public bool shote;
    public GameObject Bullet;
    public float force;
    public bool usable;
    public Transform P;

    public void Use()
    {
        if (shote)
        {
            Shote();
        }
    }

    void Shote()
    {

        GameObject bullet = Instantiate(Bullet, P.position, P.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.velocity = P.forward * force;
    }

}
