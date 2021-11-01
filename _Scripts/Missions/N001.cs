using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class N001 : MonoBehaviour
{
    public GameObject miniMapLoc;
    public GameObject missionStartPOint;
    public GameObject ourPhone;
    public GameObject sentMessage;
    public GameObject tommy;
    public AudioSource phoneFx;


    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(MissionBegin());
    }
    IEnumerator MissionBegin()
    {
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        miniMapLoc.SetActive(true);
        ourPhone.SetActive(true);
        tommy.SetActive(true);
        phoneFx.Play();
        yield return new WaitForSeconds(3);
        sentMessage.SetActive(true);
        yield return new WaitForSeconds(2);
        ourPhone.SetActive(false);
        missionStartPOint.SetActive(false);
    }
}
