using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScene : MonoBehaviour
{
    public void SelectionStage()
    {
        SceneManager.LoadScene("SelectionStage");
    }
    
    public void GoToStage1()
    {
        LoadingBarController.LoadScene("Stage1");                  // 게임 씬으로 돌아간다.
    }
    
    public void GoToStage2()
    {
        LoadingBarController.LoadScene("Stage2");                  // 게임 씬으로 돌아간다.
    }
    
    public void GoToStage3()
    {
        LoadingBarController.LoadScene("Stage3");                  // 게임 씬으로 돌아간다.
    }
}
