using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    
    public GameObject PauseMenu_text;
    public GameObject SoundMenu_canvas;

    public void Resume()
    {
        PauseMenu_text.SetActive(false);
        Time.timeScale = 1;
        GameIsPaused = false;
    }

    void Pause()
    {
        PauseMenu_text.SetActive(true);
        Time.timeScale = 0;
        GameIsPaused = true;
        SoundMenu_canvas.SetActive(false);
    }

    public void LoadMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainScene");
    }

    public void SoundMenu()
    {
        SoundMenu_canvas.SetActive(true);
        PauseMenu_text.SetActive(false);
        Time.timeScale = 0;
        GameIsPaused = true;
        
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }
    
    public void OpenPauseMenu()
    {
        Pause();
    }
}