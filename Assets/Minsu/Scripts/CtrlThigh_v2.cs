using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CtrlThigh_v2 : MonoBehaviour
{
    [SerializeField] private float legRollInSpeed = 100f;
    [SerializeField] private float legRollOutSpeed = 100f;
    [SerializeField] private bool isLeft = true;


    [Space]
    [Header("Input Key")]
    [SerializeField] private KeyCode LLeg_InputKey = KeyCode.W;
    [SerializeField] private KeyCode RLeg_InputKey = KeyCode.Q;

    [SerializeField] private KeyCode LLegFold_InputKey = KeyCode.Slash;
    [SerializeField] private KeyCode LLegUnfold_InputKey = KeyCode.Quote;
    [SerializeField] private KeyCode RLegFold_InputKey = KeyCode.Z;
    [SerializeField] private KeyCode RLegUnfold_InputKey = KeyCode.A;


    private HingeJoint hingeJoint;
    private JointMotor jointMotor;
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

        //2Key
        ManageInput_v1();

        //4Key
        ManageInput_v2();
    }

    private void RollIn()
    {
        jointMotor.targetVelocity = legRollInSpeed;
        hingeJoint.motor = jointMotor;
        //Debug.Log((isLeft ? "Left " : "Right ") + "in");
    }
    private void RollOut()
    {
        jointMotor.targetVelocity = -legRollOutSpeed;
        hingeJoint.motor = jointMotor;
        //Debug.Log((isLeft ? "Left " : "Right ") + "out");
    }
    private void RollStop()
    {
        jointMotor.targetVelocity = 0;
        hingeJoint.motor = jointMotor;
        //Debug.Log((isLeft ? "Left " : "Right ") + "stop");

    }

    private void ManageInput_v1()
    {
        if (Input.GetKeyUp(LLeg_InputKey))
        {
            //if (isLeft)
            RollStop();
        }
        else if (Input.GetKeyUp(RLeg_InputKey))
        {
            //if(!isLeft)
            RollStop();
        }

        if (Input.GetKey(RLeg_InputKey))
        {
            if (isLeft)
                RollIn();
            else
                RollOut();
        }
        else if (Input.GetKey(LLeg_InputKey))
        {
            if (isLeft)
                RollOut();
            else
                RollIn();
        }
    }

    private void ManageInput_v2()
    {
        if (Input.GetKeyUp(LLegFold_InputKey))
        {
            //if (isLeft)
            RollStop();
        }
        else if (Input.GetKeyUp(LLegUnfold_InputKey))
        {
            //if(!isLeft)
            RollStop();
        }
        else if (Input.GetKeyUp(RLegFold_InputKey))
        {
            //if(!isLeft)
            RollStop();
        }
        else if (Input.GetKeyUp(RLegUnfold_InputKey))
        {
            //if(!isLeft)
            RollStop();
        }

        if (Input.GetKey(LLegFold_InputKey))
        {
            if (isLeft)
                RollIn();
        }
        if (Input.GetKey(LLegUnfold_InputKey))
        {
            if (isLeft)
                RollOut();
        }

        if (Input.GetKey(RLegFold_InputKey))
        {
            if (!isLeft)
                RollIn();
        }
        if (Input.GetKey(RLegUnfold_InputKey))
        {
            if (!isLeft)
                RollOut();
        }
    }
}
