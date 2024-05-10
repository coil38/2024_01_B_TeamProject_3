using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;                      // UI 씬 매니팅을 하기위해 추가


public class MainScene : MonoBehaviour
{
    public void GoToGame()
    {
        SceneManager.LoadScene("Stage1");                  // 게임 씬으로 돌아간다.
    }
}
