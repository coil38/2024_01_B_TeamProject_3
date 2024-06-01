using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScene : MonoBehaviour
{
    public GameObject SelectionStage;
    public GameObject mainScene;
    
    private static string soundScene;
    
    public void QuitGame()
    {
        Application.Quit();
    }
    
    public void GotoSelectionStage()
    {
        SelectionStage.gameObject.SetActive(true);
        mainScene.gameObject.SetActive(false);
        SoundManager.instance.PlaySound("ButtonClick");
    }

    public void GotoMain()
    {
        SceneManager.LoadScene("MainScene");
        SoundManager.instance.PlaySound("ButtonClick");
    }
    
    public void GoToStage1()
    {
        LoadingBarController.LoadScene("Stage1"); 
        SoundManager.instance.PlaySound("ButtonClick");
    }
    
    public void GoToStage2()
    {
        LoadingBarController.LoadScene("Stage2"); 
        SoundManager.instance.PlaySound("ButtonClick");
    }
    
    public void GoToStage3()
    {
        LoadingBarController.LoadScene("Stage3");  
        SoundManager.instance.PlaySound("ButtonClick");
    }

    public void SoundSetting()
    {
        soundScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene("SoundSettingScene");
        SoundManager.instance.PlaySound("ButtonClick");
    }
    
    public void GoBack()
    {
        if (!string.IsNullOrEmpty(soundScene))
        {
            SceneManager.LoadScene(soundScene);
            SoundManager.instance.PlaySound("ButtonClick");
        }
    }
}
