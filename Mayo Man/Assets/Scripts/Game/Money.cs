using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour {

    private int money = 0;
    public int Bonus;
    public static int kills;
    private int MaxMoney = 100;
    public Image mBar;
	
	// Update is called once per frame
	void Update () {

        money = kills * Bonus;
        mBar.fillAmount = money / MaxMoney;
    }
}
