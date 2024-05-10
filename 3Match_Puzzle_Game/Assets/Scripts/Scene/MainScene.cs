using UnityEngine;

public class MainScene : MonoBehaviour
{
    public void GoToGame()
    {
        LoadingBarController.LoadScene("Stage1");                  // 게임 씬으로 돌아간다.
    }
}
