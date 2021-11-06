using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

        

    public Text Timer11sec;
    public EndCheck m_endCheck;
    public FailReload m_failReload;

    private float time =11;
    private float sec; //초
    private float msec;//0.1초

    private void Start()
    {
        m_endCheck = GameObject.Find("EndSwitch").GetComponent<EndCheck>();
        m_failReload = GameObject.FindGameObjectWithTag("PlayerLegR").GetComponent<FailReload>();

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

            if (time <= 0 && !m_endCheck.isEnd)
            {
                m_failReload.ThrowAway();
                break;
                //여기에 시간 체크 멈추는거 넣어주세요. (클리어 시간 내에 클리어 못했을 때 표시되는 시간 0에서 멈추게.) 
            }
            else if (m_endCheck.isEnd)
            {
                StopCoroutine(StopWatch());
                break;
                //여기에 시간 체크 멈추는거 넣어주세요. (클리어 했을 때의 시간으로 멈추게)
            }
            else if (time >= 1)
            {
                Time.timeScale = 1;
            }
            yield return null;
        }
    }
}
