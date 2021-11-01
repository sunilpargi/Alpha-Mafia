using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDestination : MonoBehaviour
{

    public int trigNum;
    public Transform firstDestination;
    public Transform secondDestination;
    public Transform thirdDestination;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Adele" || other.tag == "Nancy" || other.tag == "Stefani" || other.tag == "CoolGirl")
        {
            if (trigNum == 3)
            {
                trigNum = 0;
            }

            if (trigNum == 2)
            {
                this.gameObject.transform.position = thirdDestination.position;
                trigNum = 3;
               
            }

            if (trigNum == 1)
            {
                this.gameObject.transform.position = secondDestination.position;
                trigNum = 2;

            }

            if (trigNum == 0)
            {
                this.gameObject.transform.position = firstDestination.position;
                trigNum = 1;

            }
        
        }
    }
}
