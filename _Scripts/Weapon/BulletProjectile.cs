using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;
using UnityEngine.AI;

public class BulletProjectile : MonoBehaviour
{
    private Rigidbody rb;
    public GameObject explosionFx;
     AudioSource explosionSFX;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        explosionSFX = GetComponent<AudioSource>();
    }
    void Start()
    {
        float speed = 30f;
        rb.velocity = transform.forward * speed;

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer != 9) // bullet cartige
        {
            if (other.CompareTag("NPC"))
            {
                other.GetComponent<NpcAI>().DealDamage(10);
                other.GetComponent<Animator>().Play("Running");
                other.GetComponent<NavMeshAgent>().speed = 5;
                other.GetComponent<NpcAI>().fleeMode = true;
                
            }

            if (other.CompareTag("EnemyCar"))
            {
                if (other.GetComponent<EnemyCarCollider>())
                {
                    other.GetComponent<EnemyCarCollider>().ActivateExplosion();
                }
            }
            Instantiate(explosionFx, transform.position, Quaternion.identity);
            CinnemachineShake.instance.ShakeCamera(12f, .1f);
            explosionSFX.Play();
            Destroy(gameObject, 1f);


        }
      
    }
}
