using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllPlayerStats : MonoBehaviour
{
    //public PlayerMove Move;
    private float DamageSum = 0f;


    [SerializeField]
    public Structs.Stats PlayerStats;

    void Start()
    {
        
    }

    void Update()
    {
        DamageSum = PlayerMove.Damage;
        //Pieliks jaunus damagus kad ieliks skriptos

        PlayerStats.Health -= DamageSum;
    }

}
