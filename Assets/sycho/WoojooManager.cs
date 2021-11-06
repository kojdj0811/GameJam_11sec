using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoojooManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity = new Vector3(0, -1f, 0);
        Physics.bounceThreshold = 20;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
