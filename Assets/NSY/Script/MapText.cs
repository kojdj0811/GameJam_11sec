using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapText : MonoBehaviour
{
    public GameObject MapTexting;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(startLine());
    }
    IEnumerator startLine()
    {
      
        MapTexting.SetActive(true);
        yield return new WaitForSeconds(1.7f);
        Debug.Log("»ç¶óÁü");
        MapTexting.SetActive(false);
    }
  
}
