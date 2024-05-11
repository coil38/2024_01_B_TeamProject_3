using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] GameObject GameOverText;
    [SerializeField] float maxTime = 120f;
    float timerLeft;
    Image timerBar;
    
    void Start()
    {
        GameOverText.SetActive(false);
        timerBar = GetComponent<Image>();
        timerLeft = maxTime;
    }

    void Update()
    {
        if (timerLeft > 0)
        {
            timerLeft -= Time.deltaTime;
            timerBar.fillAmount = timerLeft / maxTime;
        }
        else
        {
            GameOverText.SetActive(true);
        }
    }

}
