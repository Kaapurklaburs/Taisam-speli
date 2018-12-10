using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour {

    Vector2 mouseLook;
    Vector2 smothV;
    public static float sensativity = 5.0f;
    public float smothing = 2.0f;

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
    }
}
