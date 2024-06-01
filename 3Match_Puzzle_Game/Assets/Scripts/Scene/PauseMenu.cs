using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject _pauseMenu;

    private static string previousScene;

    void Start()
    {
        if (SceneManager.GetActiveScene().name != "SettingsScene")
        { 
            Resume();
        }
        else if (GameIsPaused)
        {
            _pauseMenu.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void Resume()
    {
        SoundManager.instance.PlaySound("ButtonClick");
        _pauseMenu.SetActive(false);
        Time.timeScale = 1;
        GameIsPaused = false;
    }

    void Pause()
    {
        SoundManager.instance.PlaySound("ButtonClick");
        _pauseMenu.SetActive(true);
        Time.timeScale = 0;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        SoundManager.instance.PlaySound("ButtonClick");
        Time.timeScale = 1;
        GameIsPaused = false;
        SceneManager.LoadScene("MainScene");
    }

    public void QuitGame()
    {
        SoundManager.instance.PlaySound("ButtonClick");
        Application.Quit();
    }

    public void OpenPauseMenu()
    {
        SoundManager.instance.PlaySound("ButtonClick");
        Pause();
    }

    public void LoadGame1()
    {
        SoundManager.instance.PlaySound("ButtonClick");
        Time.timeScale = 1;
        GameIsPaused = false;
        SceneManager.LoadScene("Stage1");
    }

    public void LoadGame2()
    {
        SoundManager.instance.PlaySound("ButtonClick");
        Time.timeScale = 1;
        GameIsPaused = false;
        SceneManager.LoadScene("Stage2");
    }

    public void LoadGame3()
    {
        SoundManager.instance.PlaySound("ButtonClick");
        Time.timeScale = 1;
        GameIsPaused = false;
        SceneManager.LoadScene("Stage3");
    }

    public void GoToSettings()
    {
        SoundManager.instance.PlaySound("ButtonClick");
        previousScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene("SettingsScene");
    }

    public void GoBack()
    {
        if (!string.IsNullOrEmpty(previousScene))
        {
            SceneManager.LoadScene(previousScene);
            SoundManager.instance.PlaySound("ButtonClick");
        }
    }
}
