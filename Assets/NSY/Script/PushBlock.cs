using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushBlock : MonoBehaviour
{

    public Rigidbody rid;
    [Header("¹Ì´ÂÈû")]
    public float ForceMagnitude;

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        rid = hit.collider.attachedRigidbody;
        if (rid !=null)
        {
            Vector3 forceDirection = hit.gameObject.transform.position - transform.position;
            forceDirection.y = 0.0f;
            forceDirection.Normalize();

            rid.AddForceAtPosition(forceDirection * ForceMagnitude, transform.position, ForceMode.Impulse);

        }
    }



}
