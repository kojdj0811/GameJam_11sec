using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBlock : MonoBehaviour
{
    //시작하는 시간
     float XstartTime;
     float ZstartTime;
    //bool X Z
    [Header("수동체크박스")]
    public bool UseXBlock, UseZBlcok = true;
    //왔다갔다하는 최소 최대값
    [Range(-100, 100)]
    public float minX, maxX;
    [Range(-100, 100)]
    public float minZ, maxZ;
   
    //속도
    [Range(1,100)]
    public int moveSpeed;
    private int sign =-1;


   
    void FixedUpdate()
    {
        Moving();
    }
    void Moving()
    {
        if (Time.time >= XstartTime && UseXBlock)
        {
            UseZBlcok = false;
            transform.position += new Vector3(moveSpeed * Time.deltaTime * sign, 0, 0);
            if (transform.position.x <= minX || transform.position.x >= maxX)
            {
                sign *= -1;
            }
         
        }
        if (Time.time >= ZstartTime && UseZBlcok)
        {
            UseXBlock = false;
            transform.position += new Vector3(0, 0, moveSpeed * Time.deltaTime * sign);
            if (transform.position.z <= minZ || transform.position.z >= maxZ)
            {
                sign *= -1;
            }

        }

    }
     void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("이벤트 발생");
        }
       
    }

}
