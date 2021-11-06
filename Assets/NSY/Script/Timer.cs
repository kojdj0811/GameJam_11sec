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
    private float sec; //��
    private float msec;//0.1��

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
                //���⿡ �ð� üũ ���ߴ°� �־��ּ���. (Ŭ���� �ð� ���� Ŭ���� ������ �� ǥ�õǴ� �ð� 0���� ���߰�.) 
            }
            else if (m_endCheck.isEnd)
            {
                StopCoroutine(StopWatch());
                break;
                //���⿡ �ð� üũ ���ߴ°� �־��ּ���. (Ŭ���� ���� ���� �ð����� ���߰�)
            }
            else if (time >= 1)
            {
                Time.timeScale = 1;
            }
            yield return null;
        }
    }
}
