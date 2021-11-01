using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPickUP : MonoBehaviour
{
    public GameObject ourPistol;
    public AudioSource gunPickUP;
    public GameObject pistolObj;

    public Animator anim;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            gunPickUP.Play();
            ourPistol.SetActive(true);
            //    pistolObj.SetActive(true);
            this.gameObject.SetActive(false);

            anim.SetLayerWeight(2, 0f);
            anim.SetLayerWeight(1, 1f);
        }
      
    }
}
