using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour {

    public static bool IsPaused = false;
    public GameObject PauseMenuUI;
    public GameObject PauseMenu;
    public GameObject DeadMenu;
    public int G = 1;
	
	// Update is called once per frame
	void Update () {
        if (HP.PlayerDead)
        {
            DeadPause();
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
                IsPaused = true;
            }
        }

    }
   public void Resume ()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        IsPaused = false;
    }

    void Paused ()
    {
        PauseMenuUI.SetActive(true);
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
        PauseMenuUI.SetActive(true);
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
