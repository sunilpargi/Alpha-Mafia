using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSwitch : MonoBehaviour
{
    public GameObject firstCam;
    public GameObject secondCam;
    public GameObject thirdCam;
    public GameObject roleFadeIn;
    public GameObject cradStory;
    void Start()
    {
        StartCoroutine(CamSwitcher());
    }

 IEnumerator CamSwitcher()
    {
        yield return new WaitForSeconds(2f);
        roleFadeIn.SetActive(true);

        yield return new WaitForSeconds(5f);
        cradStory.SetActive(true);

        secondCam.SetActive(true);
        firstCam.SetActive(false);

        yield return new WaitForSeconds(5f);
        thirdCam.SetActive(true);
        secondCam.SetActive(false);
    }
}
