using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CtrlThighL : MonoBehaviour
{
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
            RollIn();   
        }

        if (Input.GetKey(KeyCode.W))
        {
            RollOut();
        }

        if(Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.Q))
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
        jointMotor.targetVelocity = 100;
        hingeJoint.motor = jointMotor;
        Debug.Log("in");
    }
    void RollOut()
    {
        jointMotor.targetVelocity = -100;
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
