using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swamp : MonoBehaviour
{
    [HideInInspector]
    public Transform trans;
    public Transform toehold;
    public float buoyancy = 9.0f;
    public float repulsive = 0.1f;
    public ForceMode mode = ForceMode.Acceleration;

    private void Awake() {
        trans = transform;
        toehold.SetParent(null);
    }


    private void OnTriggerEnter(Collider other) {
        var rigid = other.attachedRigidbody;
        if(rigid != null) {
            rigid.velocity *= repulsive;
        }
    }

    private void OnTriggerStay(Collider other) {
        var rigid = other.attachedRigidbody;
        if(rigid != null) {
            rigid.AddForce (Vector3.up * buoyancy, mode);
        }
    }





    private void OnDestroy() {
        if(toehold != null && toehold.gameObject != null)
            Destroy(toehold.gameObject);
    }
}
