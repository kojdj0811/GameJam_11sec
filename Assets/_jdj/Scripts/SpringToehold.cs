using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringToehold : MonoBehaviour
{
    [HideInInspector]
    public Transform trans;

    public float explosionForce = 10.0f;
    public float explosionRadius = 0.5f;
    public float upwardsModifier  = 1.0f;
    public ForceMode mode = ForceMode.Impulse;


    private void Awake() {
        trans = transform;
    }




    void OnCollisionEnter( Collision collisionInfo) 
    {
        var rigid = collisionInfo.body.GetComponent<Rigidbody>();

        if(rigid != null) {
            ContactPoint point = collisionInfo.GetContact(0);
            rigid.AddExplosionForce(explosionForce, point.point, explosionRadius, upwardsModifier, mode);
            Debug.Log("OnCollisionEnter!!!");
        }
    }
}
