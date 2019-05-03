using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private bool hasGrabd = false;
    public Transform Vieta;
    private Rigidbody rb;
    GameObject Player;
    public float GrabSpeed = 0.1f;
    public float Range = 1.5f;
    public float dropForce;
    [SerializeField]
    
    public ItemInfo ITEM;
    public GameObject ITEM_Go;
    public Structs.Item Hand;

    void Start()
    {
        Player = this.transform.parent.gameObject;
    }

    private void FixedUpdate()
    {


       if (Input.GetButtonDown("Fire1"))
       {
          if (!hasGrabd)
          {
              RaycastHit hit;
              if (Physics.Raycast(transform.position, transform.forward, out hit, Range))
              {
                  rb = hit.transform.GetComponent<Rigidbody>();
                    ItemInfo it = hit.transform.GetComponent<ItemInfo>();
                  if(rb != null && it != null)
                  {
                      Vieta.position = rb.position;
                      rb.useGravity = false;
                      hasGrabd = true; 
                  }
     
              }
            }
            else
            {
                rb.rotation = Player.transform.rotation;
                hasGrabd = false;
                rb.useGravity = true;
                rb.AddForce(transform.forward * dropForce, ForceMode.Impulse);
            }

  
       }
       if (Input.GetButtonDown("Fire2"))
       {
            if (hasGrabd)
            {
                rb.rotation = Player.transform.rotation;
                hasGrabd = false;
                rb.useGravity = true;
            }
            else
            {
                RaycastHit hit2;
                if (Physics.Raycast(transform.position, transform.forward, out hit2, Range))
                {
                    ITEM = hit2.transform.GetComponent<ItemInfo>();
                    ITEM_Go = hit2.transform.gameObject;
                    if (ITEM != null && ITEM_Go != null)
                    {
                        ItemContainer.AddItem(ItemContainer.Contents, ITEM.Item);
                        ITEM_Go.SetActive(false);
                    }

                }
            }
       }
       if (hasGrabd)
       {
            Vector3 SmothPosition = Vector3.Lerp(rb.position, Vieta.position, GrabSpeed);
            rb.position = SmothPosition;
            rb.rotation = Player.transform.rotation;

       }
    }
}


