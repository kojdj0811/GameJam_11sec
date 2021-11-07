using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endingManager : MonoBehaviour
{
    public AudioClip[] soundClip = new AudioClip[4];
    AudioSource m_AudioSource;
    // Start is called before the first frame update
    void Start()
    {
        m_AudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void quit()

    {
        Application.Quit();
    }

    public void SoundPlay(int n)
    {
        m_AudioSource.clip = soundClip[n];
        m_AudioSource.Play();
        

    }
}
