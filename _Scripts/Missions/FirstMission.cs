using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class FirstMission : MonoBehaviour
{
    public static FirstMission instance { get; private set; }
    public GameObject missionStartPOint;
    public GameObject tommy;
    public GameObject fadeOut;
    public GameObject fadeIn;
    public GameObject uI;
    public GameObject player;
    public GameObject mainCamera;
    public GameObject Timeline;
    public PlayableDirector playableDirector;

    public GameObject gameSounds;
    public int destroyCars;

    public GameObject actionSound;
    public GameObject policeSirenSound;
    public GameObject gameWinSound;
    public GameObject missionCompleteText;
  
    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if(destroyCars >= 4)
        {
            actionSound.SetActive(false);
            policeSirenSound.SetActive(false);
            gameWinSound.SetActive(true);
           // gameSounds.SetActive(true);
            missionCompleteText.SetActive(true);

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(MissionBegin());
        }
    }

    IEnumerator MissionBegin()
    {
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        missionStartPOint.SetActive(false);
        fadeOut.SetActive(true);
        player.SetActive(false); // player
       uI.SetActive(false);
       gameSounds.SetActive(false);
      


        yield return new WaitForSeconds(2);
        fadeOut.SetActive(false);
        mainCamera.SetActive(false);
        mainCamera.SetActive(true);
        Timeline.SetActive(true);
        //  playableDirector.playOnAwake = true;

        //yield return new WaitForSeconds(40f);
        ////mainCamera.SetActive(true);
        ////player.SetActive(true);
        //uI.SetActive(true);


    }
}
