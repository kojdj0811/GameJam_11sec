using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBlock : MonoBehaviour
{
    [Header("���ۺ��/���������")]
    public GameObject StartBlock;
    public GameObject EndBlock;
    [Header("���ӵ�")]
    public int moveSpeed;
    //�Դٰ���
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






    //�浹///////////////////////////////////////////////////////
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
            Debug.Log("�̺�Ʈ �߻�");
        }
       
    }

}
