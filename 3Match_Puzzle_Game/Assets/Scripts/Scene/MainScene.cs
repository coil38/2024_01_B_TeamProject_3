using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;                      // UI �� �Ŵ����� �ϱ����� �߰�


public class MainScene : MonoBehaviour
{
    public void GoToGame()
    {
        SceneManager.LoadScene("Stage1");                  // ���� ������ ���ư���.
    }
}
