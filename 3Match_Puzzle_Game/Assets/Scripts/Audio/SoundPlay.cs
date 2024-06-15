using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundPlay : MonoBehaviour
{
    private string previousSceneName;

    void Start()
    {
        previousSceneName = SceneManager.GetActiveScene().name;
        SoundSelection();
    }

    void Update()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        if (currentSceneName != previousSceneName)
        {
            previousSceneName = currentSceneName;
            SoundSelection();
        }
    }

    void SoundSelection()
    {
        // 현재 씬의 이름을 가져옴
        string currentSceneName = SceneManager.GetActiveScene().name;
        
        Debug.Log($"현재 씬 이름은 {currentSceneName}입니다.");

        if (currentSceneName == "MainScene")
        {
            SoundManager.instance.PlaySound("BackGround");
            SoundManager.instance.StopSound("Stage1");
            SoundManager.instance.StopSound("Stage2");
            SoundManager.instance.StopSound("Stage3");
            return;
        }

        // 모든 사운드를 중지한 후 새로운 사운드를 재생
        SoundManager.instance.StopSound("BackGround");
        SoundManager.instance.StopSound("Stage1");
        SoundManager.instance.StopSound("Stage2");
        SoundManager.instance.StopSound("Stage3");
        SoundManager.instance.StopSound("StoryBGM");

        // 스테이지 사운드
        if (currentSceneName == "Stage1" || currentSceneName == "Stage2" || currentSceneName == "Stage3")
        {
            SoundManager.instance.PlaySound("Stage1");
        }
        else if (currentSceneName == "Stage4" || currentSceneName == "Stage5" || currentSceneName == "Stage6")
        {
            SoundManager.instance.PlaySound("Stage2");
        }
        else if (currentSceneName == "Stage7" || currentSceneName == "Stage8" || currentSceneName == "Stage9")
        {
            SoundManager.instance.PlaySound("Stage3");
        }

        // 스토리 사운드
        if (currentSceneName == "MainStoryScene" || currentSceneName == "Story3" || currentSceneName == "Story6" ||
            currentSceneName == "EndingStory")
        {
            SoundManager.instance.PlaySound("StoryBGM");
        }
    }
}
