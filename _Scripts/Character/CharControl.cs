using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharControl : MonoBehaviour
{
    public GameObject thePlayer;
    public float horizontalMove;
    public float verticalMove;
    public bool isRunning;
    public int stepNum;
    public bool isStepping;
    public AudioSource footStep1;
    public AudioSource footStep2;

    void Update()
    {
        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        {
            thePlayer.GetComponent<Animation>().Play("Run");
            horizontalMove = Input.GetAxis("Horizontal") * Time.deltaTime * 150;
            verticalMove = Input.GetAxis("Vertical") * Time.deltaTime * 8;
            isRunning = true;
            if (isStepping == false)
            {
                StartCoroutine(RunSound());
            }
            transform.Rotate(0, horizontalMove, 0);
            transform.Translate(0, 0, verticalMove);
        }

        else
        {
            if(FiringPistol.isFiring == false)
            {

            isRunning = false;
            thePlayer.GetComponent<Animation>().Play("Idle");
            }
        }
    }

    IEnumerator RunSound()
    {
        if (isRunning == true && isStepping == false)
        {
            isStepping = true;
            stepNum = Random.Range(1, 3);

            if (stepNum == 1)
            {
                footStep1.Play();
            }
            else
            {
                footStep2.Play();
            }
        }

        yield return new WaitForSeconds(.3f);
        isStepping = false;
    }
}
