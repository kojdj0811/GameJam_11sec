using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndCrane : MonoBehaviour
{
    [SerializeField] Rigidbody[] playerRigid;
    [SerializeField] GameObject player;
    [SerializeField] GameObject playerparents;

    [SerializeField] bool EndCraneDown;
    [SerializeField] bool EndCraneMove;
    [SerializeField] float speed;

    private void LateUpdate()
    {
        if (EndCraneMove)
            transform.position = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
        if (EndCraneDown)
            transform.Translate(Vector3.down * Time.deltaTime * speed);
    }
    private void Start()
    {
        SoundManager.instance.SoundEffect("SceneStart");

    }
    public void CraneMoveStart()
    {
        EndCraneMove = true;
        EndCraneDown = true;
    }

    void FollowCrane()
    {
        if(EndCraneDown)
            transform.Translate(Vector3.down * Time.deltaTime * speed);

    }

    IEnumerator MoveCraneUp()
    {
        float time = 2f;
        float Upspeed = 8;
        SoundManager.instance.SoundEffect("SceneEnd");

        while (time >= 0)
        {
            time -= Time.deltaTime;
            transform.Translate(Vector3.up * Time.deltaTime * Upspeed);

            yield return null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("sdf");
            EndCraneDown = false;
            EndCraneMove = false;
            playerparents.transform.SetParent(gameObject.transform);
            playerRigid[0].constraints = RigidbodyConstraints.FreezeAll;

            for (int i = 0; i< playerRigid.Length; i++)
            {
                playerRigid[i].useGravity = false;
                //other.gameObject.transform.parent = gameObject.transform;


            }
            StartCoroutine(MoveCraneUp());
        }
    }




}
