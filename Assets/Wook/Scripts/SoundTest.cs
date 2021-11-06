using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTest : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKey(KeyCode.U))
            SoundManager.instance.SoundEffect("Test");
        if (Input.GetKey(KeyCode.I))
            SoundManager.instance.PlayBGM("TestBGM");

    }
}
