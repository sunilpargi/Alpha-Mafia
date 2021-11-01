using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCAlert : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "NPC")
        {
        
            other.GetComponent<Animator>().Play("Terrified");
            other.GetComponent<NavMeshAgent>().speed = 0;
            //other.GetComponent<NpcAI>().fleeMode = true;
        }
    }
}
