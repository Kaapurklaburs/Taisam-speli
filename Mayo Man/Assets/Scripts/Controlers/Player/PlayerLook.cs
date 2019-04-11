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
    public HingeJoint hj;
    private bool hasGrabd = false;
    public float DropForce;

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
            if (hasGrabd)
            {
                //       Drop();
            }
            else
            {
                Grab();
            }

        }
    }

    void Grab()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, Range))
        {

            Rigidbody rb = hit.transform.GetComponent<Rigidbody>();
            if (rb != null)
            {

                hj.connectedAnchor = new Vector3(0f, 0f, 1.5f);
                hj.connectedBody = rb;
                hasGrabd = true;
            }
        }
    }

    void Drop()
    {
        hj.connectedBody = null;
        hasGrabd = false;
    }
}
