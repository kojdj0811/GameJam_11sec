using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CtrlThigh_v2 : MonoBehaviour
{
    [SerializeField] private float legRollInSpeed = 100f;
    [SerializeField] private float legRollOutSpeed = 100f;
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
        if (Input.GetKeyUp(KeyCode.W))
        {
            //if (isLeft)
            RollStop();
        }
        else if (Input.GetKeyUp(KeyCode.Q))
        {
            //if(!isLeft)
            RollStop();
        }

        if (Input.GetKey(KeyCode.Q))
        {
            if (isLeft)
                RollIn();
            else
                RollOut();
        }
        else if (Input.GetKey(KeyCode.W))
        {
            if (isLeft)
                RollOut();
            else
                RollIn();
        }
        
        
        

        /*
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.Q))
        {
            RollStop();
        }*/
        /*
        if (isLeft)
        {
            if (Input.GetKeyUp(KeyCode.Q))
                RollStop();
        }
        else
        {
            if (Input.GetKeyUp(KeyCode.W))
                RollStop();
        }
        */
        //    if(!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.Q))
        //    {
        //        RollStop();
        //    }
        /*if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.Q))
        {
            RollStop();
        }*/
    }

    void RollIn()
    {
        jointMotor.targetVelocity = legRollInSpeed;
        hingeJoint.motor = jointMotor;
        // Debug.Log((isLeft ? "Left " : "Right ") + "in");
    }
    void RollOut()
    {
        jointMotor.targetVelocity = -legRollOutSpeed;
        hingeJoint.motor = jointMotor;
        // Debug.Log((isLeft ? "Left " : "Right ") + "out");
    }
    void RollStop()
    {
        jointMotor.targetVelocity = 0;
        hingeJoint.motor = jointMotor;
        // Debug.Log((isLeft ? "Left " : "Right ") + "stop");

    }
}
