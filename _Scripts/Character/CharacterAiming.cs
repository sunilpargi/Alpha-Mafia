using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterAiming : MonoBehaviour
{
    public Cinemachine.AxisState xAxis;
    public Cinemachine.AxisState yAxis;
    public Transform cameraLookAt;

    public Animator anim;
    public bool isAiming;
    int isAimingParam = Animator.StringToHash("IsAiming");

    public GameObject npcAlert;
    public AudioClip coinPickUp;

    public Text coinText;
    public int coinCount;
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

    }


    private void Update()
    {
        isAiming = Input.GetMouseButton(1);
        anim.SetBool(isAimingParam, isAiming);

        if (isAiming)
        {
            npcAlert.SetActive(true);
        }
        else
        {
            npcAlert.SetActive(false);


        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            anim.Play("Punching");
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            anim.Play("Kick");
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            anim.Play("Punch Combo");
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            anim.Play("Kick Soccerball");
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            anim.Play("Excite");
        }
    }

    void FixedUpdate()
    {
        xAxis.Update(Time.fixedDeltaTime);
        yAxis.Update(Time.fixedDeltaTime);

        cameraLookAt.eulerAngles = new Vector3(yAxis.Value, xAxis.Value, 0);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            GetComponent<AudioSource>().PlayOneShot(coinPickUp);
            coinCount += 100;
            coinText.text = "$000" + coinCount;
            other.gameObject.SetActive(false);
        }
    }
}
