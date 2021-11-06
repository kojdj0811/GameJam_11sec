using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toehold : MonoBehaviour
{
    [HideInInspector]
    public Transform trans;


    private Transform foots;

    private void Awake() {
        trans = transform;
    }

    // void OnCollisionStay( Collision collisionInfo) 
    // { 
    //     Debug.Log(collisionInfo.contacts.Length);
    // }

    // void OnCollisionExit( Collision collisionInfo) 
    // { 
    //     Debug.Log(collisionInfo.contacts.Length);
    // }

}
