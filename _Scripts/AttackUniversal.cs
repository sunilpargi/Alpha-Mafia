using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackUniversal : MonoBehaviour
{
    public LayerMask collisionLayer;
    public float radius = 1f;
    public int damage ;
    public AudioSource attackSound;
    public AudioClip[] punches;

    void Update()
    {
        DetectCollision();
    }

    void DetectCollision()
    {

        Collider[] hit = Physics.OverlapSphere(transform.position, radius, collisionLayer);

        if (hit.Length > 0)
        {

            if (this.gameObject.CompareTag("LeftLeg")) // coin factory
            {
                if (hit[0].gameObject.CompareTag("HeadphoneGuy")) // headphone guy
                {
                    hit[0].GetComponent<NpcAI>().ActivateGoldFast();
                    int random = Random.Range(0, 5);
                    attackSound.PlayOneShot(punches[random]);
                }

                if (hit[0].gameObject.CompareTag("Stefani")) // headphone guy
                {
                    hit[0].GetComponent<NpcAI>().ActivateGoldFast();
                    int random = Random.Range(0, 5);
                    attackSound.PlayOneShot(punches[random]);
                }
                if (hit[0].gameObject.CompareTag("Nancy")) // headphone guy
                {
                    hit[0].GetComponent<NpcAI>().ActivateGoldFast();
                    int random = Random.Range(0, 5);
                    attackSound.PlayOneShot(punches[random]);
                }
            }
            if (!this.gameObject.CompareTag("LeftLeg")) 
            {
               
                if (hit[0].gameObject.CompareTag("HeadphoneGuy")) // headphone guy
                {
                    if (!hit[0].GetComponent<NpcAI>().isDead)
                    {
                        hit[0].GetComponent<NpcAI>().HeadphoneGuyHurt();
                        hit[0].GetComponent<NpcAI>().DealDamage(damage);
                       
                    }
                    
                }

                if (hit[0].gameObject.CompareTag("Stefani")) // stefani
                {
                    hit[0].GetComponent<NpcAI>().HurtAnimation();
                    hit[0].GetComponent<NpcAI>().DealDamage(damage);
                   
                }

                if (hit[0].gameObject.CompareTag("Nancy")) // nancy
                {
                   
                    hit[0].GetComponent<NpcAI>().HurtAnimation();
                    hit[0].GetComponent<NpcAI>().DealDamage(damage);

                }
                int random = Random.Range(0, 5);
                attackSound.PlayOneShot(punches[random]);
                CinnemachineShake.instance.ShakeCamera(3f, .1f);
             

            }
                  

            } // if is player


            gameObject.SetActive(false);

        } // if we have a hit


    } // detect collision

