using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChange : MonoBehaviour
{
   public void NextSceneLevel1()
    {
        SceneManager.LoadScene("level 2");
    }
    public void NextSceneLevel2()
    {
        SceneManager.LoadScene("level 3");
    }
    public void NextSceneLevel3()
    {
        SceneManager.LoadScene("level 4");
    }
    public void NextSceneLevel4()
    {
        SceneManager.LoadScene("level 5");
    }
    public void NextSceneLevel5()
    {
        SceneManager.LoadScene("level 6");
    }
    public void NextSceneLevel6()
    {
        SceneManager.LoadScene("level 7");
    }
 
}
