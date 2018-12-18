using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP : MonoBehaviour {

    public float hp = 100f;
    private float hp2 = 100;
    public GameObject me;
    public static float dumage;
    public bool IsPlayer = false;
    public static bool PlayerDead = false;

    public void Dumage()
    {
        hp2 = hp - dumage;
        hp = hp2;
        if (hp <= 0f)
        {
            if (IsPlayer)
            {
                PlayerDead = true;
                Pause.IsPaused = true;
            }
            else
            {
                me.SetActive(false);
            }
           
        }
    }
}
