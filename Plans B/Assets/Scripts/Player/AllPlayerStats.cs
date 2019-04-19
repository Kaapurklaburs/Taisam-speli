using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllPlayerStats : MonoBehaviour
{
    //public PlayerMove Move;
    private float DamageSum = 0f;

    [System.Serializable]
    public struct Stats
    {
        public float Health;
        public Stats(float Health)
        {
            this.Health = Health;
        }
        public void Damage(float D)
        {
            this.Health -= D;
        }
    }
    [SerializeField]
    public Stats PlayerStats;

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
