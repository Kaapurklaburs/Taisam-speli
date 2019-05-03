using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemContainer : MonoBehaviour
{
    
    public static float MaxVollume;
    public static float Vollume;
    public static Dictionary<Structs.Item, int> Contents = new Dictionary<Structs.Item, int>();
    
    //var Contents = new Dictionary<Structs.Item, int>;

    public static Dictionary<Structs.Item, int> AddItem(Dictionary<Structs.Item, int> Cont , Structs.Item item)
    {
        
        foreach (var key in Cont)
        {
            Vollume += key.Value;
        }
        if (Vollume + item.amount < MaxVollume)
        {
            if (Cont.ContainsKey(item))
            {
                Cont[item]++;
            }
            else
            {
                Cont.Add(item, 1);
            }
        }
        return Cont;
    }

}
