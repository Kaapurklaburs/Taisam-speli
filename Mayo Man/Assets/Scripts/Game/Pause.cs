﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour {

    public static bool IsPaused = false;
    public GameObject PauseMenuUI;
    public GameObject PauseMenu;
    public GameObject DeadMenu;
    public int G = 1;


    private void Start()
    {
    PauseMenuUI.SetActive(true);      
    }

    // Update is called once per frame
    void Update()
    {
        if (HP.PlayerDead)
        {
            DeadPause();
        }
        else
        {
            if (IsPaused == false)
            {
           if (Input.GetKey("t"))
            {
                Time.timeScale = 0.4f;
            }
            else
            {
                Time.timeScale = 1f;
            }
            }
 
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsPaused)
            {
                Resume();
            }
            else
            {
                Paused();
            }
        }

    }
    public void Resume()
    {
        PauseMenu.SetActive(false);
        DeadMenu.SetActive(false);
        Time.timeScale = 1f;
        IsPaused = false;
    }

    void Paused()
    {
        PauseMenu.SetActive(true);
        DeadMenu.SetActive(false);
        Time.timeScale = 0f;
        IsPaused = true;
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - G);
    }
    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
    void DeadPause()
    {
        PauseMenu.SetActive(false);
        DeadMenu.SetActive(true);
        Time.timeScale = 0f;
        IsPaused = true;
    }
    public void Retry()
    {
        IsPaused = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        HP.PlayerDead = false;
        Time.timeScale = 1f;


    }
}
