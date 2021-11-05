using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBlock : MonoBehaviour
{
    //�����ϴ� �ð�
     float XstartTime;
     float ZstartTime;
    //bool X Z
    [Header("����üũ�ڽ�")]
    public bool UseXBlock, UseZBlcok = true;
    //�Դٰ����ϴ� �ּ� �ִ밪
    [Range(-100, 100)]
    public float minX, maxX;
    [Range(-100, 100)]
    public float minZ, maxZ;
   
    //�ӵ�
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
            Debug.Log("�̺�Ʈ �߻�");
        }
       
    }

}
