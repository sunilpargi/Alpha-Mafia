using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NpcAI : MonoBehaviour
{
    public GameObject destinationPoint;
    NavMeshAgent theAgent;
    public  bool fleeMode;
    public GameObject fleeDest;
    public bool isFleeing;
    public AudioSource helpMEFX;

    public int health = 30;
    Animator anim;
    public GameObject bloodStain;

    public GameObject[] bloodparticle;

    public GameObject interactiveCollider;
    public ParticleSystem chunkParicle;
    public GameObject coin;
    public bool isDead;
    public bool funnyMagnet;
    public Transform playerFront;
    public Transform playerback;
    public Transform playerFront2;

    public bool stoped;
    public AudioSource discoAudioSource;
    void Start()
    {
        theAgent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.CapsLock))
        {
            funnyMagnet = true;
            if(discoAudioSource != null)
            {
                discoAudioSource.Play();
            }             
        }
       
        if (fleeMode == false && funnyMagnet == false && !stoped)
        {
            
             theAgent.SetDestination(destinationPoint.transform.position);
        }

        if (fleeMode == true)
        {
            theAgent.speed = 3;
            theAgent.SetDestination(fleeDest.transform.position);
            if(isFleeing == false)
            {
                isFleeing = true;
                anim.Play("Running");
                StartCoroutine(FleeingNPC());
            }
        }

        if (funnyMagnet && !stoped)
        {
            theAgent.speed = 3;
            if (gameObject.CompareTag("Nancy"))
            {
                 theAgent.SetDestination(playerFront.position);
                 anim.Play("Running");
            }

            if (gameObject.CompareTag("Adele"))
            {              
                    theAgent.SetDestination(playerback.position);
                    anim.Play("Running");              

            }

            if (gameObject.CompareTag("CoolGirl"))
            {
                theAgent.SetDestination(playerFront2.position);
                anim.Play("Running");

            }
        }

        
    }


    IEnumerator FleeingNPC()
    {
        helpMEFX.Play();
        GetComponent<AnimationEvent>().PlayScreamSound();
        yield return new WaitForSeconds(10);
        fleeMode = false;
        isFleeing = false;
        funnyMagnet = false;
        stoped = false;
        this.gameObject.GetComponent<Animator>().Play("Walking");
        this.gameObject.GetComponent<NavMeshAgent>().speed = 2;
    }

    public void DealDamage(int _damage)
    {
        health -= _damage;

        if(health <= 0)
        {
            isDead = true;
            StopAllCoroutines();
            anim.SetTrigger("Death");
            GetComponent<AnimationEvent>().PlayDeathSound();

            for(int i = 0; i < bloodparticle.Length; i++)
            {
                bloodparticle[i].SetActive(true);
            }

            theAgent.speed = 0;
           // theAgent.enabled = false;
            interactiveCollider.SetActive(false);
          
            
            GetComponent<NpcAI>().enabled = false;
            if (funnyMagnet)
            {
                GlobalWanted.activateStar = true;
                FindObjectOfType<NpcAI>().fleeMode = true;

            }
            StartCoroutine(ActivateGold());

        }
    }

    public IEnumerator ActivateGold()
    {
        yield return new WaitForSeconds(3.16f);
        coin.SetActive(true);
        bloodStain.SetActive(true);
        anim.enabled = false;
    }

    public void HurtAnimation()
    {
        interactiveCollider.SetActive(false);
        if (discoAudioSource != null && discoAudioSource.isPlaying)
        { 
            discoAudioSource.Stop();
        }

        anim.Play("Hurt");
        theAgent.speed = 0;

        if (funnyMagnet)
        {
           FindObjectOfType<NpcAI>().PlayTerrifiedAnim();
        }
    }
    public void ActivateGoldFast()
    {
        chunkParicle.Play();
        coin.SetActive(true);
    }

    public void HeadphoneGuyHurt()
    {
        if (!isDead)
        {
            int random = Random.Range(1, 3);

            if (random == 1)
            {

                anim.Play("Hurt");
            }
            if (random == 2)
            {

                anim.Play("Hurt 2");
            }

            theAgent.speed = 0;
            transform.LookAt(GameObject.FindGameObjectWithTag("Player").transform);

            StartCoroutine(HeadphoneGuyAttack());
        }
           
    }

    IEnumerator HeadphoneGuyAttack()
    {
      

        if (!isDead)
        {
            yield return new WaitForSeconds(4f);
            if (isDead)
            {
                yield return null;
            }
            int random = Random.Range(0, 2);
            if (random == 0)
            {
                anim.Play("Kick");
            }

            if (random == 1)
            {
                anim.Play("Punch");
            }

            StartCoroutine(HeadphoneGuyAttack());
        }
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (funnyMagnet)
        {
            if (other.CompareTag("PlayerBack") || other.CompareTag("PlayerFront"))
            {
                interactiveCollider.SetActive(false);
                stoped = true;
                theAgent.speed = 0;
                anim.Play("Excite");
            }
        }
       
    }

    public void PlayTerrifiedAnim()
    {
        // GameObject.FindGameObjectWithTag("CoolGirl").GetComponent<NpcAI>().PlayTerrifiedAnim();
        // if(!gameObject.CompareTag("Stefani"))
        //  anim.Play("Terrified");
        Debug.Log(1);
            anim.Play("Terrified");
        
    }
}
