using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallPlane : MonoBehaviour
{

    public float CountDown;
    [SerializeField] float FallTime;
    [SerializeField] float Fallspeed;
    [SerializeField] bool isFall = false;

    bool IsLegL = false;
    bool IsLegR = false;


    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator FallCountDown()
    {

        while(CountDown >= 0)
        {
            CountDown -= Time.deltaTime;

            yield return null;
        }
        StartCoroutine(Fall());
    }

    IEnumerator Fall()
    {
        while (FallTime >= 0)
        {
            FallTime -= Time.deltaTime;
            transform.Translate(Vector3.down * Time.deltaTime * Fallspeed);


            yield return null;
        }
    }




    private void OnCollisionEnter(Collision collision)
    {

        if (collision.transform.tag == "PlayerLegL" &&!IsLegL && !IsLegR)
        {
            Debug.Log("ll");
            IsLegL = true;
            StartCoroutine(FallCountDown());
        }
        if (collision.transform.tag == "PlayerLegR" && !IsLegL && !IsLegR)
        {
            Debug.Log("lR");

            IsLegR = true;
            StartCoroutine(FallCountDown());
        }

        //if(IsLegL && IsLegR)
        //    StartCoroutine(FallCountDown());

    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.tag == "PlayerLegL")
        {
            IsLegL = false;
        }
        if (collision.transform.tag == "PlayerLegR")
        {
            IsLegR = false;
        }
    }
}
