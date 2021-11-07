using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FailReload : MonoBehaviour
{
    public float speed;
    public GameObject m_pelvic;
    public GameObject m_gameoverPanel;
    public GameObject m_gameoverText;

    // Start is called before the first frame update
    void Start()
    {
        speed = 4000f;
        m_gameoverPanel = GameObject.Find("GameoverPanel");
        m_gameoverText = GameObject.Find("GameoverText");
        m_gameoverPanel.GetComponent<Image>().enabled = false;
        m_gameoverText.GetComponent<Text>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bottom")
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            ///////Minsu
            GameObject fadeOutObj = GameObject.Find("/SceneTransition1/TransitionCanvas/Transition1_fadeOut_shorter");
            if (fadeOutObj != null)
            {
                fadeOutObj.SetActive(true);
            }
            else
            {
                Debug.Log("Error. Couldn't find SceneTransition GameObject.");
            }
            /////////////
        }
        if (other.tag == "MovingBlock")
        {
            ThrowAway();
        }
    }
    public void ThrowAway()
    {
        int i = Random.Range(0, 3);
        switch (i)
        {
            case 0:
                SoundManager.instance.SoundEffect("Trashed1");
                break;
            case 1:
                SoundManager.instance.SoundEffect("Trashed2");
                break;
            case 2:
                SoundManager.instance.SoundEffect("Trashed3");
                break;
        }
        m_gameoverPanel.GetComponent<Image>().enabled = true;
        m_gameoverText.GetComponent<Text>().enabled = true;
        m_pelvic.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        m_pelvic.GetComponent<Rigidbody>().AddForce(new Vector3(1, 1, 0) * speed);
    }
   
}
