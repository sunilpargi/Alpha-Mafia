using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GlobalAmmo : MonoBehaviour
{
    public GameObject ammoDisplay;
    public static int pistolShots;

    void Update()
    {
        ammoDisplay.GetComponent<Text>().text = "" + pistolShots;
    }
}
