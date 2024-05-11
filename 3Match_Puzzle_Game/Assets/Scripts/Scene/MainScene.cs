using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScene : MonoBehaviour
{
    public void SelectionStage()
    {
        SceneManager.LoadScene("SelectionStage");
    }

    public void GotoMain()
    {
        SceneManager.LoadScene("MainScene");
    }
    
    public void GoToStage1()
    {
        LoadingBarController.LoadScene("Stage1");                  
    }
    
    public void GoToStage2()
    {
        LoadingBarController.LoadScene("Stage2");                  
    }
    
    public void GoToStage3()
    {
        LoadingBarController.LoadScene("Stage3");                  
    }

    public void SoundSetting()
    {
        SceneManager.LoadScene("SoundSettingScene");
    }

    public void BackGameScene1()
    {
        SceneManager.LoadScene("Stage1");
    }
    
    public void BackGameScene2()
    {
        SceneManager.LoadScene("Stage2");
    }
    
    public void BackGameScene3()
    {
        SceneManager.LoadScene("Stage3");
    }
    
    public void OnBackButtonClick() {
        SceneManager.LoadScene("MainScene");
    }

    public void GoToInGameSound1()
    {
        SceneManager.LoadScene("InGameSound 1");
    }
    
    public void GoToInGameSound2()
    {
        SceneManager.LoadScene("InGameSound 2");
    }
    
    public void GoToInGameSound3()
    {
        SceneManager.LoadScene("InGameSound 3");
    }
}
