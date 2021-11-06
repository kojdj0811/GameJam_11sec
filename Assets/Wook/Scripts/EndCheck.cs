using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndCheck : MonoBehaviour
{
    [SerializeField] GameObject Button;
    [SerializeField] float buttonSpeed;
    Vector3 ButtonMovePos;

    public bool isEnd = false;

    [SerializeField] GameObject arrow;
    [SerializeField] float rotateSpeed;
    [SerializeField] float UpDownSPeed;

    [SerializeField] EndCrane endCrane;

    float UpDownTime = 1;
    bool isUp = true;
    private void Awake()
    {
        ButtonMovePos = new Vector3(Button.transform.position.x, Button.transform.position.y - 0.01f, Button.transform.position.z);
        endCrane = FindObjectOfType<EndCrane>();
    }

    private void Update()
    {
        arrow.transform.Rotate(new Vector3(0, 0, -rotateSpeed * Time.deltaTime));
        if (isUp)
        {
            arrow.transform.Translate(Vector3.up * Time.deltaTime * UpDownSPeed, Space.World);
        }
        else
        {
            arrow.transform.Translate(Vector3.down * Time.deltaTime * UpDownSPeed, Space.World);
        }
            UpDownTime -= Time.deltaTime;

        if (UpDownTime <= 0)
        {
            UpDownTime = 1;
            isUp = !isUp;
        }

    }

    void End()
    {
        isEnd = true;
        StartCoroutine(MoveButton());

        //
        GameObject fadeOutObj = GameObject.Find("/SceneTransition1/TransitionCanvas/Transition1_fadeOut");
        if (fadeOutObj != null)
        {
            fadeOutObj.SetActive(true);
        }
        else
        {
            Debug.Log("Error. Couldn't find SceneTransition GameObject.");
        }
    }

    IEnumerator MoveButton()
    {
        float time = 0.23f;
        while(time >= 0)
        {
            Button.transform.Translate(Vector3.down * Time.deltaTime*buttonSpeed, Space.World);
            time -= Time.deltaTime;
            //Button.transform.position = Vector3.MoveTowards(transform.position, ButtonMovePos, 3 * Time.deltaTime);
            yield return null;
        }


    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!isEnd &&(collision.transform.tag == "PlayerLegL" || collision.transform.tag == "PlayerLegR"))
        {
            int i = Random.Range(0,4);
            if(i == 0)
                SoundManager.instance.SoundEffect("ButtonReal");
            else
                SoundManager.instance.SoundEffect("Button");
            endCrane.CraneMoveStart();
            End();
        }
            
    }
}
