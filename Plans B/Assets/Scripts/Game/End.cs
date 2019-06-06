using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End : MonoBehaviour
{
    public bool OneTime;
    public float LifeTime;
    private float countDown;

    // Start is called before the first frame update
    void Start()
    {
        countDown = LifeTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (OneTime == false)
        {
            countDown -= Time.deltaTime;
            if (countDown <= 0f)
            {
                gameObject.SetActive(false);
            }
        }
        else
        {
            Destroy(gameObject, LifeTime);
        }
    }
}
