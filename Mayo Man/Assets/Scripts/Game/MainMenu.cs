using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public void LoadGame1()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Pause.IsPaused = false;
        HP.PlayerDead = false;
        Time.timeScale = 1f;

    }
    public void LoadGame2()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        Pause.IsPaused = false;
        HP.PlayerDead = false;
        Time.timeScale = 1f;
    }
    public void LoadGame3()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
        Pause.IsPaused = false;
        HP.PlayerDead = false;
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
    /*
    public void SetSlider(float Sensativity)
    {
        PlayerLook.sensativity = Sensativity;
    }
    */
}
