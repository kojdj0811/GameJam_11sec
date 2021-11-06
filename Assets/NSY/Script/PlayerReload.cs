using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerReload : MonoBehaviour
{
   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ReLoad();
        }
    }

    public void ReLoad()
    {
        
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            
        

    }
 
}
