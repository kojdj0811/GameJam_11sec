using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endingManager : MonoBehaviour
{
    public AudioClip[] soundClip = new AudioClip[4];
    AudioSource m_AudioSource;
    private bool canQuitGame = false;


    // Start is called before the first frame update
    void Start()
    {
        m_AudioSource = GetComponent<AudioSource>();
    }

    public void Update()
    {
        if (canQuitGame)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                Debug.Log("Application.Quit()");
                Application.Quit();
            }
        }
    }

    public void quit()
    {
        canQuitGame = true;
        Debug.Log("Can quit from now by pressing ESC key.");
    }

    public void SoundPlay(int n)
    {
        m_AudioSource.clip = soundClip[n];
        m_AudioSource.Play();
        

    }
}
