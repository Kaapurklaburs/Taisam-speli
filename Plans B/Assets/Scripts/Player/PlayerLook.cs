﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    Vector2 mouseLook;
    Vector2 smothV;
    public float sensativity = 1.0f;
    public float smothing = 2.0f;
    GameObject Player;
    public Transform Head;
    public float Offset;
    public float height;



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

        Vector3 Heh = new Vector3(0f, height, 0f);
        transform.position = Head.forward * Offset + Head.position + Heh;
       

    }
}
