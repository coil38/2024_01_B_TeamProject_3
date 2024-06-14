using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScene : MonoBehaviour
{
    public GameObject SelectionStage;
    public GameObject mainScene;
    public GameObject _soundCanvas;
    
    public GameObject _selectionStage1;
    public GameObject _selectionStage2;
    public GameObject _selectionStage3;

    private IEnumerator TransitionToNextStage()
    {
        // 페이드 아웃 효과
        FadeEffect fadeEffect = FindObjectOfType<FadeEffect>();
    
        if (fadeEffect != null)
        {
            yield return StartCoroutine(fadeEffect.Fade(0f, 1f)); // 페이드 아웃
        }
    
        // 씬 로드
        LoadingBarController.LoadScene("MainStoryScene");
        
        /*SoundManager.instance.PlaySound("StoryBGM");
        SoundManager.instance.StopSound("BackGround");*/
    
        // 페이드 인 효과
        if (fadeEffect != null)
        {
            yield return StartCoroutine(fadeEffect.Fade(1f, 0f)); // 페이드 인 (시간은 0.5초로 설정)
        }
    }

    public void EndingStoryScene()
    {
        SceneManager.LoadScene("EndingStory");
    }
    
    public void MainStoryScene()
    {
        StartCoroutine(TransitionToNextStage());
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }
    
    public void GotoSelectionStage()
    {   
        SelectionStage.gameObject.SetActive(true);
        _selectionStage1.gameObject.SetActive(false);
        _selectionStage2.gameObject.SetActive(false);
        _selectionStage3.gameObject.SetActive(false);
        mainScene.gameObject.SetActive(false);
        SoundManager.instance.PlaySound("ButtonClick");
    }

    public void SelectionStage1()
    {
        _selectionStage1.gameObject.SetActive(true);
        SelectionStage.gameObject.SetActive(false);
        SoundManager.instance.PlaySound("ButtonClick");
    }
    
    public void SelectionStage2()
    {
        _selectionStage1.gameObject.SetActive(false);
        _selectionStage2.gameObject.SetActive(true);
        SelectionStage.gameObject.SetActive(false);
        SoundManager.instance.PlaySound("ButtonClick");
    }
    
    public void SelectionStage3()
    {
        _selectionStage1.gameObject.SetActive(false);
        _selectionStage2.gameObject.SetActive(false);
        _selectionStage3.gameObject.SetActive(true);
        SelectionStage.gameObject.SetActive(false);
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
