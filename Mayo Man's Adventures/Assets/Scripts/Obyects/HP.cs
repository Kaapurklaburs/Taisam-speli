using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP : MonoBehaviour {

    private float hp;
    private float hp2;
    public float startHP;
    public GameObject me;
    public static float dumage;
    public bool IsPlayer = false;
    public static bool PlayerDead = false;
    public static float Php;
    public Image HPbar;

    private void Start()
    {
        hp = startHP;
        hp2 = hp;
    }

    public void Dumage()
    {
        hp2 = hp - dumage;
        hp = hp2;
        if (IsPlayer)
        {
            Php = hp;
            HPbar.fillAmount = Php / startHP;
        }
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
