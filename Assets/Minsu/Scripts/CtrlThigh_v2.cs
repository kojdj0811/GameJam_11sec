using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CtrlThigh_v2 : MonoBehaviour
{
    [SerializeField] private float legRollInSpeed = 100;
    [SerializeField] private float legRollOutSpeed = 100;
    [SerializeField] private bool isLeft = true;

    HingeJoint hingeJoint;
    JointMotor jointMotor;
    // Start is called before the first frame update
    void Start()
    {
        hingeJoint = this.GetComponent<HingeJoint>();
        jointMotor = hingeJoint.motor;
        jointMotor.targetVelocity = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            if (isLeft)
                RollIn();
            else
                RollOut();
        }

        if (Input.GetKey(KeyCode.W))
        {
            if (isLeft)
                RollOut();
            else
                RollIn();
        }

        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.Q))
        {
            RollStop();
        }
        //    if(!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.Q))
        //    {
        //        RollStop();
        //    }
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.Q))
        {
            RollStop();
        }
    }

    void RollIn()
    {
        jointMotor.targetVelocity = legRollInSpeed;
        hingeJoint.motor = jointMotor;
        Debug.Log("in");
    }
    void RollOut()
    {
        jointMotor.targetVelocity = -legRollOutSpeed;
        hingeJoint.motor = jointMotor;
        Debug.Log("out");
    }
    void RollStop()
    {
        jointMotor.targetVelocity = 0;
        hingeJoint.motor = jointMotor;
        Debug.Log("stop");

    }
}
