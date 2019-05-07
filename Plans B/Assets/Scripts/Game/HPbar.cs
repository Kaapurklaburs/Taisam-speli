using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPbar : MonoBehaviour
{
    public AllPlayerStats ps;
    public Image hpBar;
    private float hp1;
    private float hp2;



    public float amount { get; internal set; }

    private void Start()
    {
        hp1 = ps.PlayerStats.Health;
    }

    void Update()
    {
        hp2 = ps.PlayerStats.Health;
        hpBar.fillAmount = hp2 / hp1;
    }
}
