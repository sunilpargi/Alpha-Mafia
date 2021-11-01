using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvent : MonoBehaviour
{
    public GameObject left_Leg;
    public GameObject right_Leg;
    public GameObject right_hand;
    public GameObject left_hand;

    public AudioClip deathSound, wooshSound, bloodSlash, terrified, woamnScream, malePunchHitScream, femalePunchHitScream;
    public AudioSource audioSource;
   public AudioSource secondAudioSource;

    public GameObject mainCamera;
    public GameObject uI;
    private void Start()
    {
      
    }

    public void Activate_Left_Leg()
    {
      
        left_Leg.SetActive(true);
    }
    public void Dectivate_Left_Leg()
    {
        left_Leg.SetActive(false);
    }


    public void Activate_Right_Leg()
    {
      
        right_Leg.SetActive(true);
    }
    public void Dectivate_Right_Leg()
    {

        right_Leg.SetActive(false);
    }

    public void Activate_Right_Hand()
    {
      
        right_hand.SetActive(true);
    }

    public void Dectivate_Right_Hand()
    {
        right_hand.SetActive(false);
    }

    public void Activate_left_Hand()
    {
      
        left_hand.SetActive(true);
    }

    public void Dectivate_left_Hand()
    {
        left_hand.SetActive(false);
    }


    public void PlayDeathSound()
    {
        audioSource.PlayOneShot(deathSound);
        secondAudioSource.PlayOneShot(bloodSlash);
    }

    public void PlayWooshSound()
    {
        audioSource.PlayOneShot(wooshSound);
    }
    public void PlayTerriedSound()
    {
        audioSource.PlayOneShot(terrified);      
    }
    public void PlayScreamSound()
    {
        audioSource.PlayOneShot(woamnScream);
    }

    public void PlayMalepunchHitScreamSound()
    {
        audioSource.PlayOneShot(malePunchHitScream);
    }

    public void PlayFeMalepunchHitScreamSound()
    {
        audioSource.PlayOneShot(femalePunchHitScream);
    }

    public void ActivateMainCamera()
    {
        mainCamera.SetActive(true);
        uI.SetActive(true);
    }
}
