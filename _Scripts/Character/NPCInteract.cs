using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteract : MonoBehaviour
{
    public AudioSource[] voiceLine;
    int randomNum;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            StartCoroutine(VoiceLine());
        }
    }

    IEnumerator VoiceLine()
    {
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        randomNum = Random.Range(0, 3);
        voiceLine[randomNum].Play();
        yield return new WaitForSeconds(2);
        this.gameObject.GetComponent<BoxCollider>().enabled = true;
    }
}
