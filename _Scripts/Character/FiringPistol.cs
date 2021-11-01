using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiringPistol : MonoBehaviour
{
    public bool isAiming;
    public GameObject thePlayer;
    public AudioSource pistolShot;
    public static bool isFiring;
    public GameObject aimingObj;

    public float distanceToTarget;
    public float toTarget;
    public int shotDamage;

    void Update()
    {
        RaycastHit hit;

        if (Input.GetMouseButton(1))
        {
            isAiming = true;
            if(isFiring == false)
            thePlayer.GetComponent<Animation>().Play("Aiming 1Pistol");
            aimingObj.SetActive(true);

        }
        else
        {
            isAiming = false;
            aimingObj.SetActive(false);

        }

        if(isAiming == true && Input.GetMouseButtonDown(0))
        {
            if(GlobalAmmo.pistolShots > 0)
            {
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
                {
                    toTarget = hit.distance;
                    distanceToTarget = toTarget;
                    shotDamage = 50;
                    hit.transform.SendMessage("HurtNPC", shotDamage, SendMessageOptions.DontRequireReceiver);
                }
                isFiring = true;
                pistolShot.Play();
                GlobalAmmo.pistolShots -= 1;
                thePlayer.GetComponent<Animation>().Play("Fire_1Pistol");
                StartCoroutine(FireThePistol());
            }
          
        }
    }

    IEnumerator FireThePistol()
    {
        yield return new WaitForSeconds(0.4f);
        isFiring = false;
    }
}
