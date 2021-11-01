using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;
public class VehicleExit : MonoBehaviour
{
    public GameObject vehicleCam;
    public GameObject thePlayer;
    public GameObject liveVehicle;
    public GameObject entryTrig;
    public GameObject crossHair;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            entryTrig.GetComponent<BoxCollider>().enabled = false;
            thePlayer.SetActive(true);
            crossHair.SetActive(true);
            vehicleCam.SetActive(false);
            liveVehicle.GetComponent<CarController>().enabled = false;
            liveVehicle.GetComponent<CarUserControl>().enabled = false;
            liveVehicle.GetComponent<CarAudio>().enabled = false;
            thePlayer.transform.parent = null;
          StartCoroutine(EnterAgain());
        }
    }
    IEnumerator EnterAgain()
    {
        yield return new WaitForSeconds(.5f);
        entryTrig.GetComponent<BoxCollider>().enabled = true;
        this.gameObject.SetActive(false);
    }
}
