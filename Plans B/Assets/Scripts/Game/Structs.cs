using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Structs : MonoBehaviour
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
    [System.Serializable]
    public struct Item
    {
        public string Name;
        public int amount;
        public float volume;
    }
}
