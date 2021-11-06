using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerReload : MonoBehaviour
{
   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.Escape))
        {
            ReLoad();
        }
    }

    public void ReLoad()
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

}
