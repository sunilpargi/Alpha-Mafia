using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;


public class VoiceSub : MonoBehaviour
{
    public GameObject subText;
    public AudioSource voice1;
    public AudioSource voice2;
    public AudioSource voice3;
    public AudioSource voice4;
    public AudioSource voice5;
    public AudioSource loudBang;
    public GameObject fullBlack;
    public GameObject deathObj;
    public GameObject theSack;
    public GameObject theCop;
    public GameObject theChar;
    public GameObject fourCAm;
    public GameObject fadeIn;
    public GameObject fadeOut;
    void Start()
    {
        StartCoroutine(IntroSubs());
    }
    IEnumerator IntroSubs()
    {
        yield return new WaitForSeconds(8);
        subText.GetComponent<Text>().text = "You asked for this bobby";
        voice1.Play();
        subText.SetActive(true);
        yield return new WaitForSeconds(1);
        subText.GetComponent<Text>().text = "";
        yield return new WaitForSeconds(1);
        subText.GetComponent<Text>().text = "I swear it was not me";
        voice2.Play();
        yield return new WaitForSeconds(1.5f);
        subText.GetComponent<Text>().text = "";
        yield return new WaitForSeconds(.5f);
        subText.GetComponent<Text>().text = "Yes it was you";
        voice3.Play();
        yield return new WaitForSeconds(2.7f);
        subText.GetComponent<Text>().text = "";
        yield return new WaitForSeconds(.1f);
        subText.GetComponent<Text>().text = "No, please";
        voice4.Play();
        yield return new WaitForSeconds(.7f);
        subText.GetComponent<Text>().text = "";
        yield return new WaitForSeconds(.3f);
        loudBang.Play();
        fullBlack.SetActive(true);
        //theSack.SetActive(false);
        theCop.SetActive(false);
        //theChar.SetActive(false );
        yield return new WaitForSeconds(2f);
        subText.GetComponent<Text>().text = "My name is 007";
        voice5.Play();
        yield return new WaitForSeconds(2f);
        fadeIn.SetActive(true);
        fadeIn.SetActive(false);
        fullBlack.SetActive(false);
        fourCAm.SetActive(true);
        deathObj.SetActive(true);
        subText.GetComponent<Text>().text = "Three years ago";
        yield return new WaitForSeconds(5f);
        subText.GetComponent<Text>().text = "Now its my time to return the favor";
        yield return new WaitForSeconds(3f);
        subText.GetComponent<Text>().text = "";
        yield return new WaitForSeconds(2f);
        fadeOut.SetActive(true);
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(1);
    }
}
 