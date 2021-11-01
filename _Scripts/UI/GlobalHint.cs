using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalHint : MonoBehaviour
{
    public GameObject hintText;
    public Animator hintBox;
    public static int hintNumber;

    public GameObject PhoneCall;
    public Animator playerAnim;
    public GameObject phoneRingingSound;

    void Update()
    {
        if(hintNumber == 1)
        {
            hintNumber = 0;
            hintText.GetComponent<Text>().text = "Kill All the police and protect barbos";
            hintBox.Play("HIntFade");
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
          
            phoneRingingSound.SetActive(true);
            PhoneCall.SetActive(true);
            hintText.GetComponent<Text>().text = "Press 1 for pick up the phone";
            hintBox.Play("HIntFade");

        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
          
            phoneRingingSound.SetActive(false);
            playerAnim.SetTrigger("PhoneCall");
            StartCoroutine(MissionHinttext());
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {

            hintText.GetComponent<Text>().text = "Press 6 for cool dance moves";
            hintBox.Play("HIntFade");
        }

    }

    IEnumerator MissionHinttext()
    {
        yield return new WaitForSeconds(17f);
        PhoneCall.GetComponent<Animator>().Play("SlideOut");
        hintText.GetComponent<Text>().text = "Meet barbos at his home";
        hintBox.Play("HIntFade");

    }
}
