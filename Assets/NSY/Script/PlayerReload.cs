using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerReload : MonoBehaviour
{
   
    void Update()
    {
        ReLoad();
    }

    public void ReLoad()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            
        }

    }
 
}
