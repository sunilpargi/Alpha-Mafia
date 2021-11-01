using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opening : MonoBehaviour
{
    public GameObject fadeIN;
    public GameObject theText;
    public GameObject initialCam;
    public GameObject fadeOut;
    public GameObject thePlayer;
    public GameObject killerFake;
    public GameObject cashAmount;
    public GameObject ammoAmount;
    public GameObject hintBox;
    public GameObject miniMap ;
    void Start()
    {
        StartCoroutine(OpenBegin());   
    }
     

    IEnumerator OpenBegin()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        yield return new WaitForSeconds(1);
        theText.SetActive(true);
        yield return new WaitForSeconds(7);
        fadeIN.GetComponent<Animator>().enabled = true;
        initialCam.GetComponent<Animator>().enabled = true;
        yield return new WaitForSeconds(3);
        fadeOut.SetActive(true);
        fadeIN.SetActive(false);
        yield return new WaitForSeconds(2.5f);
        killerFake.SetActive(false);
        thePlayer.SetActive(true);  
        initialCam.SetActive(false);
        fadeOut.SetActive(false);
        fadeIN.SetActive(true);
        cashAmount.SetActive(true);
        ammoAmount.SetActive(true);
        hintBox.SetActive(true);
        miniMap.SetActive(true);
        fadeIN.GetComponent<Animator>().Play("FadeIn");
        yield return new WaitForSeconds(4f);
        fadeIN.SetActive(false);
        GlobalHint.hintNumber = 1;

    }
}
