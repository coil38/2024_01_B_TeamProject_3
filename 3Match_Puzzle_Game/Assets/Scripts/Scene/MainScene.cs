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
        LoadingBarController.LoadScene("Stage1");                  // ���� ������ ���ư���.
    }
    
    public void GoToStage2()
    {
        LoadingBarController.LoadScene("Stage2");                  // ���� ������ ���ư���.
    }
    
    public void GoToStage3()
    {
        LoadingBarController.LoadScene("Stage3");                  // ���� ������ ���ư���.
    }
}
