using System.Collections;
using System.Collections.Generic;
using UnityEngine;
enum MoveDir
{
    Front = 0,
    Back,
}
public class MovePlane : MonoBehaviour
{
    [SerializeField] Transform TrunPointFront;
    [SerializeField] Transform TrunPointBack;
    [SerializeField] GameObject Object;

    [SerializeField] MoveDir moveDir;
    [SerializeField] float Speed;
    [SerializeField] float halfSize;

    bool IsLegL = false;
    bool IsLegR = false;


    private void Update()
    {
        Move();
    }

    void MoveToFront(Vector3 targetPos)
    {
        var TargetPos = new Vector3(targetPos.x + halfSize, targetPos.y, targetPos.z);
        transform.position = Vector3.MoveTowards(transform.position, TargetPos, Speed * Time.deltaTime);

    }

    private void Move()
    {
        switch (moveDir)
        {
            case MoveDir.Front:
                MoveToFront(TrunPointFront.position);
                break;
            case MoveDir.Back:
                MoveToFront(TrunPointBack.position);

                break;
        }


    }


    private void OnCollisionEnter(Collision collision)
    {

        if (collision.transform.tag == "PlayerLegL")
        {
            IsLegL = true;
            PlayerParentChange(collision.gameObject);
        }
        if (collision.transform.tag == "PlayerLegR")
        {
            IsLegR = true;
            PlayerParentChange(collision.gameObject);
        }
    }

    void PlayerParentChange(GameObject player)
    {
        if(IsLegL  && IsLegR)
        {
            player.gameObject.transform.parent.gameObject.transform.parent = transform;

        }
        else
        {
            player.gameObject.transform.parent.gameObject.transform.parent = null;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.tag == "PlayerLegL")
        {
            IsLegL = false;
            PlayerParentChange(collision.gameObject);
        }
        if (collision.transform.tag == "PlayerLegR")
        {
            IsLegR = false;
            PlayerParentChange(collision.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        if (other.tag == "TurnFront")
        {
            Debug.Log("front 충돌");
            moveDir = MoveDir.Back;
        }
        else if (other.tag == "TurnBack")
        {

            Debug.Log("back 충돌");

            moveDir = MoveDir.Front;

        }
    }
}



