using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBlock : MonoBehaviour
{
    [Header("시작블록/끝지점블록")]
    public GameObject StartBlock;
    public GameObject EndBlock;
    [Header("블럭속도")]
    public int moveSpeed;
    //왔다갔다
    Vector3 CubVec;

    bool isGostart;

  
    void FixedUpdate()
    {
       
        Moving();
    }
    void Moving()
    {
       
       // transform.position = Vector3.MoveTowards(transform.position, EndBlock.transform.position, moveSpeed*Time.deltaTime);
        if (isGostart)
        {
            transform.position = Vector3.MoveTowards(transform.position, StartBlock.transform.position, moveSpeed * Time.deltaTime);

        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, EndBlock.transform.position, moveSpeed * Time.deltaTime);

        }
    }






    //충돌///////////////////////////////////////////////////////
     void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("EndBlock"))
        {
            isGostart = true;
        }
        if (other.gameObject.CompareTag("StartBlock"))
        {
            isGostart = false;
        }
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("이벤트 발생");
        }
       
    }

}
