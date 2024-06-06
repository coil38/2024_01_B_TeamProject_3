using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScene : MonoBehaviour
{
    public GameObject SelectionStage;
    public GameObject mainScene;
    public GameObject _soundCanvas;
    
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
    
    public void GoToStage4()
    {
        LoadingBarController.LoadScene("Stage4");  
        SoundManager.instance.PlaySound("ButtonClick");
    }
    
    public void GoToStage5()
    {
        LoadingBarController.LoadScene("Stage5");  
        SoundManager.instance.PlaySound("ButtonClick");
    }
    
    public void GoToStage6()
    {
        LoadingBarController.LoadScene("Stage6");  
        SoundManager.instance.PlaySound("ButtonClick");
    }
    
    public void GoToStage7()
    {
        LoadingBarController.LoadScene("Stage7");  
        SoundManager.instance.PlaySound("ButtonClick");
    }
    
    public void GoToStage8()
    {
        LoadingBarController.LoadScene("Stage8");  
        SoundManager.instance.PlaySound("ButtonClick");
    }
    
    public void GoToStage9()
    {
        LoadingBarController.LoadScene("Stage9");  
        SoundManager.instance.PlaySound("ButtonClick");
    }

    public void SoundSetting()
    {
        _soundCanvas.gameObject.SetActive(true);
        mainScene.gameObject.SetActive(false);
        SoundManager.instance.PlaySound("ButtonClick");
    }
}
