using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class M001 : MonoBehaviour
{
    public GameObject tommyCam;
    public GameObject thePlayer;
    public GameObject fadeIn;
    public GameObject fadeOut;
    public GameObject subText;
    public AudioSource tonyLine;
    public GameObject cashAmount;
    public GameObject ammoAmount;
    public GameObject hintBox;
    public GameObject miniMap;
    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(TonyMeet());
    }

    IEnumerator TonyMeet()
    {
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        fadeOut.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        cashAmount.SetActive(false);
        ammoAmount.SetActive(false);
        hintBox.SetActive(false);
        miniMap.SetActive(false);
        tommyCam.SetActive(true);
        thePlayer.GetComponent<CharControl>().enabled = false;
        fadeIn.SetActive(true);
        fadeOut.SetActive(false);
        yield return new WaitForSeconds(1.5f);
        fadeIn.SetActive(false);
        subText.SetActive(true);
        tonyLine.Play();
        yield return new WaitForSeconds(7f);
        subText.SetActive(false);
        yield return new WaitForSeconds(.5f);
        fadeOut.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        tommyCam.SetActive(false);
        thePlayer.GetComponent<CharControl>().enabled = true;
        fadeIn.SetActive(true);
        fadeOut.SetActive(false);
        cashAmount.SetActive(true);
        ammoAmount.SetActive(true);
        hintBox.SetActive(true);
        miniMap.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        fadeIn.SetActive(false);

    }
}
