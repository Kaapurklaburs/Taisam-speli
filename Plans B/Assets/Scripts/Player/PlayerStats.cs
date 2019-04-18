using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
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
    public static Stats PlayerSts;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    /*
    Stats Damage(Stats P, float D)
    {
        P.Health -= D;
        return P;
    }
    */
}
