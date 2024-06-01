using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlay : MonoBehaviour
{
    void Start()
    {
        SoundManager.instance.PlaySound("BackGround");      // BackGround Àç»ý
    }
}
