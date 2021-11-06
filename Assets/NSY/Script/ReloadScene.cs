using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ReloadScene : MonoBehaviour
{
   

    // Update is called once per frame
    

    public void ClickReloadBtn()
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
