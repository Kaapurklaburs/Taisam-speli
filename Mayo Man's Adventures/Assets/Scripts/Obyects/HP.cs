using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP : MonoBehaviour {

    private float hp;
    public float startHP;
    public GameObject me;
    public static float dumage;
    public bool IsPlayer = false;
    public static bool PlayerDead = false;
    public static float Php;
    public Image HPbar;
    public GameObject leftOver;
    public Vector3 offset;

    private void Start()
    {
        hp = startHP;
    }

    public void Dumage()
    {
        hp -= dumage;


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
                Debug.Log("+ 1 kill");
                Die();
            }
           
        }
    }

    void Die()
    {
        Debug.Log("+ 1 kill");

        Money.kills += 1;
        Destroy(gameObject);
     }
}
