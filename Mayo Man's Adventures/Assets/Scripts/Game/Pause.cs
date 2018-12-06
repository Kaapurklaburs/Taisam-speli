using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour {

    public static bool IsPaused = false;
    public GameObject PauseMenuUI;
	
	// Update is called once per frame
	void Update () {
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
   public void Resume ()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        IsPaused = false;
    }

    void Paused ()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        IsPaused = true;
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }
    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
}
