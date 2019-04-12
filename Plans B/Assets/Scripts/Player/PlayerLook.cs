using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    Vector2 mouseLook;
    Vector2 smothV;
    public float sensativity = 1.0f;
    public float smothing = 2.0f;
    public float Range;
    private bool hasGrabd = false;
    public float DropForce;
    public Transform Vieta;
    private Rigidbody rb;
    GameObject Player;


    void Start()
    {
        Player = this.transform.parent.gameObject;
    }

    void Update()
    {
        var md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        md = Vector2.Scale(md, new Vector2(sensativity * smothing, sensativity * smothing));
        smothV.x = Mathf.Lerp(smothV.x, md.x, 1f / smothing);
        smothV.y = Mathf.Lerp(smothV.y, md.y, 1f / smothing);
        mouseLook += smothV;

        transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
        Player.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, Player.transform.up);

        if (Input.GetButton("Fire1"))
        {
            if (!hasGrabd)
            {
               RaycastHit hit;
               if (Physics.Raycast(transform.position, transform.forward, out hit, Range))
               {
                    rb = hit.transform.GetComponent<Rigidbody>();
                    Vieta.position = rb.position;
                    rb.useGravity = false;
                    hasGrabd = true;      
                }
            }

        }
        if (Input.GetButton("Fire2"))
        {
            hasGrabd = false;
            rb.rotation = Player.transform.rotation;
            rb.useGravity = true;
        }

        if (hasGrabd)
        {
            rb.MovePosition(Vieta.position);
            rb.rotation = Player.transform.rotation;
        }


    }
}
