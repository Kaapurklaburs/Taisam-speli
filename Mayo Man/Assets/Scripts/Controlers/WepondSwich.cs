using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WepondSwich : MonoBehaviour {

    public int SelectedWepond = 0;

	// Use this for initialization
	void Start () {
        SelectWepond();
	}
	
	// Update is called once per frame
	void Update () {

        int PreviusSelectedWepond = SelectedWepond;

        if(Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (SelectedWepond >= transform.childCount - 1)
                SelectedWepond = 0;
            else
                SelectedWepond++;
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (SelectedWepond <= 0)
                SelectedWepond = transform.childCount - 1;
            else
                SelectedWepond--;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SelectedWepond = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >= 2)
        {
            SelectedWepond = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && transform.childCount >= 3)
        {
            SelectedWepond = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4) && transform.childCount >= 4)
        {
            SelectedWepond = 3;
        }



        if (PreviusSelectedWepond != SelectedWepond)
        {
            SelectWepond();
        }

    }
    void SelectWepond()
    {
        int i = 0;
        foreach(Transform wepond in transform)
        {
            if (i == SelectedWepond)

                wepond.gameObject.SetActive(true);
            else
                wepond.gameObject.SetActive(false);
            i++;
        }
    }
}
