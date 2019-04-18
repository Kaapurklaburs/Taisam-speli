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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DamageSum = PlayerMove.Damage;
        //Pieliks jaunus damagus kad ieliks skriptos

        PlayerStats.Health -= DamageSum;
    }
    /*
    Stats Damage(Stats P, float D)
    {
        P.Health -= D;
        return P;
    }
    */
}
