using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject _pauseMenu;
    public GameObject _soundCanvas;

    public void OpenSoundCanvas()
    {
        _soundCanvas.gameObject.SetActive(true);
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
        _soundCanvas.gameObject.SetActive(false);
        Pause();
    }

    public void LoadGame1()
    {
        SoundManager.instance.PlaySound("ButtonClick");
        Time.timeScale = 1;
        GameIsPaused = false;
        SceneManager.LoadScene("Stage1");
        SoundManager.instance.PlaySound("BackGround");
    }

    public void LoadGame2()
    {
        SoundManager.instance.PlaySound("ButtonClick");
        Time.timeScale = 1;
        GameIsPaused = false;
        SceneManager.LoadScene("Stage2");
        SoundManager.instance.PlaySound("BackGround");
    }

    public void LoadGame3()
    {
        SoundManager.instance.PlaySound("ButtonClick");
        Time.timeScale = 1;
        GameIsPaused = false;
        SceneManager.LoadScene("Stage3");
        SoundManager.instance.PlaySound("BackGround");
    }
    
    public void LoadGame4()
    {
        SoundManager.instance.PlaySound("ButtonClick");
        Time.timeScale = 1;
        GameIsPaused = false;
        SceneManager.LoadScene("Stage4");
        SoundManager.instance.PlaySound("BackGround");
    }
    
    public void LoadGame5()
    {
        SoundManager.instance.PlaySound("ButtonClick");
        Time.timeScale = 1;
        GameIsPaused = false;
        SceneManager.LoadScene("Stage5");
        SoundManager.instance.PlaySound("BackGround");
    }
    
    public void LoadGame6()
    {
        SoundManager.instance.PlaySound("ButtonClick");
        Time.timeScale = 1;
        GameIsPaused = false;
        SceneManager.LoadScene("Stage6");
        SoundManager.instance.PlaySound("BackGround");
    }
    
    public void LoadGame7()
    {
        SoundManager.instance.PlaySound("ButtonClick");
        Time.timeScale = 1;
        GameIsPaused = false;
        SceneManager.LoadScene("Stage7");
        SoundManager.instance.PlaySound("BackGround");
    }
    
    public void LoadGame8()
    {
        SoundManager.instance.PlaySound("ButtonClick");
        Time.timeScale = 1;
        GameIsPaused = false;
        SceneManager.LoadScene("Stage8");
        SoundManager.instance.PlaySound("BackGround");
    }
    
    public void LoadGame9()
    {
        SoundManager.instance.PlaySound("ButtonClick");
        Time.timeScale = 1;
        GameIsPaused = false;
        SceneManager.LoadScene("Stage9");
        SoundManager.instance.PlaySound("BackGround");
    }

    public void GoToSettings()
    {
        SoundManager.instance.PlaySound("ButtonClick");
        SceneManager.LoadScene("SettingsScene");
    }
}
