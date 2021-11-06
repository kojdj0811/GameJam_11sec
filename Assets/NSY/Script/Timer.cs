using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public GameObject gameOverPanel;
        

    public Text Timer11sec;

    private float time =11;
    private float sec; //√ 
    private float msec;//0.1√ 

    private void Start()
    {
      
        StopCoroutine(StopWatch());
        if (time == 11)
        {
            StartCoroutine(StopWatch());
        }
       
    }
    IEnumerator StopWatch()
    {
        while(true)
        {
            time -= Time.deltaTime;
            msec = (int)((time - (int)time) * 100);
            sec = time;

            Timer11sec.text = string.Format("{0:00}.{1:00}",sec,msec);

            if (time <= 0)
            {
                gameOverPanel.SetActive(true);
                Time.timeScale = 0;
            }
            else if (time >= 1)
            {
                Time.timeScale = 1;
            }
            yield return null;
        }
    }
}
