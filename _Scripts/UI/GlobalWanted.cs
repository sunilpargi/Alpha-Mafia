using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalWanted : MonoBehaviour
{
    public GameObject[] wantedStars;
    public static int wantedLevel;
    public bool addingStar;
    [SerializeField]public static bool activateStar;
    public AudioSource audioSource;

   void Start()
    {
        wantedLevel = 1;
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        if(addingStar == false && activateStar == true)
        {
            activateStar = false;
            addingStar = true;
            audioSource.Play();
            StartCoroutine(AddStar());
        }
        //else
        //{
        //    audioSource.Stop();
        //}
       
    }

    IEnumerator AddStar()
    {
        for(int i = 0; i < 30; i++)
        {
            wantedStars[wantedLevel - 1].SetActive(true);
            yield return new WaitForSeconds(0.5f);
            wantedStars[wantedLevel - 1].SetActive(false);
            yield return new WaitForSeconds(0.5f);
        }
        //wantedStars[wantedLevel - 1].SetActive(true);
        //yield return new WaitForSeconds(0.5f);
        //wantedStars[wantedLevel - 1].SetActive(false);
        //yield return new WaitForSeconds(0.5f);
        //wantedStars[wantedLevel - 1].SetActive(true);
        //yield return new WaitForSeconds(0.5f);
        //wantedStars[wantedLevel - 1].SetActive(false);
        //yield return new WaitForSeconds(0.5f);
        //wantedStars[wantedLevel - 1].SetActive(true);
        //yield return new WaitForSeconds(0.5f);
        //wantedStars[wantedLevel - 1].SetActive(false);
        //yield return new WaitForSeconds(0.5f);
        //wantedStars[wantedLevel - 1].SetActive(true);
        //yield return new WaitForSeconds(0.5f);
        //wantedStars[wantedLevel - 1].SetActive(false);
        //yield return new WaitForSeconds(0.5f);
        //wantedStars[wantedLevel - 1].SetActive(true);
        audioSource.Stop();
    }
}
