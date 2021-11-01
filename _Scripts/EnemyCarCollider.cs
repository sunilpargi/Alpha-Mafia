using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public class EnemyCarCollider : MonoBehaviour
{
    public GameObject smokeParticle;
    public GameObject fireParticle;
  

    public void ActivateExplosion()
    {
        FirstMission.instance.destroyCars++;
        GetComponent<CarAIControl>().enabled = false;
        GetComponent<CarAudio>().enabled = false;
        GetComponent<CarController>().enabled = false;

        smokeParticle.SetActive(true);
        fireParticle.SetActive(true);
    }
}
