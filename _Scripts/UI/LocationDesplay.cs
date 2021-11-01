using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LocationDesplay : MonoBehaviour
{
    public string locationName;
    public GameObject locationDisplay;


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
            locationDisplay.GetComponent<Text>().text = locationName;
            locationDisplay.GetComponent<Animator>().Play("LocationNAme");
            StartCoroutine(ResetLoc());
        }
    }


    IEnumerator ResetLoc()
    {
        yield return new WaitForSeconds(7);
        locationDisplay.GetComponent<Animator>().Play("New State");
        this.gameObject.GetComponent<BoxCollider>().enabled = false;


    }
}
