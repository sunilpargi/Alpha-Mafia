using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControl : MonoBehaviour
{
    public float rotationSpeed = 200f;
  
    void Update()
    {
       if(Input.GetAxis("Mouse X") < 0)
        {
            transform.Rotate(0, -rotationSpeed * Time.deltaTime, 0);
        }

        if (Input.GetAxis("Mouse X") > 0)
        {
            transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
        }
    }
}
