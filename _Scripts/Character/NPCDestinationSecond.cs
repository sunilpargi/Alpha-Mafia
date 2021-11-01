using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDestinationSecond : MonoBehaviour
{

 
    public int genPos;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "NPC")
        {
            genPos = Random.Range(1, 4);

            if (genPos == 3)
            {
                this.gameObject.transform.position = new Vector3(141, 0.56f, 100);
            }

            if (genPos == 2)
            {
                this.gameObject.transform.position = new Vector3(141, 0.56f, 100);
               
            }

            if (genPos == 1)
            {
                this.gameObject.transform.position = new Vector3(141, 0.56f, 86);
               
            }
      
        }
    }
}
