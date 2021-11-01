using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCDeath : MonoBehaviour
{
    public int npcHealth = 20;
    public bool npcDeath;
    public GameObject npcObj;
    public GameObject interactiontrigger;
    public GameObject helpMe;
    void Update()
    {
        this.transform.position = npcObj.transform.position;

        if(npcHealth <= 0)
        {
            npcDeath = true;
            StartCoroutine(EndNPC());
        }
    }

    void HurtNPC(int shotDamage)
    {
        npcHealth -= shotDamage;
    }

    IEnumerator EndNPC()
    {
        GlobalWanted.wantedLevel += 1;
        GlobalWanted.activateStar = true;
        npcObj.GetComponent<NpcAI>().enabled = false;
        npcObj.GetComponent<NavMeshAgent>().enabled = false;
        npcObj.GetComponent<BoxCollider>().enabled = false;
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        interactiontrigger.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        npcObj.GetComponent<Animator>().Play("Dying");
        helpMe.SetActive(false);
        yield return new WaitForSeconds(3);
        npcObj.GetComponent<Animator>().enabled = false;


    }
}
