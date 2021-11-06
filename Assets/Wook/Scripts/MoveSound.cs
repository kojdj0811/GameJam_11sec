using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSound : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        int i = Random.Range(0, 3);
        switch(i)
        {
            case 1:
                SoundManager.instance.SoundEffect("Move1");
                break;
            case 2:
                SoundManager.instance.SoundEffect("Move2");
                break;
            case 3:
                SoundManager.instance.SoundEffect("Move3");
                break;
        }

    }
}
