using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.InputSystem;


public class ThirdPersonMove : MonoBehaviour
{
    public CharacterController characterController;
    public float speed, sprintModifier , normalSpeed;
    public Transform cam;

    public float turnSomoothTime = 0.1f;
    float turnSmoothVelocity;

    public Animator anim;
    public bool aim; // input
    public bool shoot; // input
    [SerializeField] private CinemachineVirtualCamera aimVirtualCamera;
  //  [SerializeField] private LayerMask aimCollider = new LayerMask();
    //[SerializeField] private Transform debugTransform;
    [SerializeField] private Transform bulletProjectile;
    [SerializeField] private Transform spawnBulletPos;

    CharacterAiming characterAiming;
    public WeaponCtrl weaponCtrl;
    public Transform footPoint;

    public GameObject playerSound;
    PlayerFootSteps playerFootSteps;
    private void Start()
    {
        characterAiming = GetComponent<CharacterAiming>();
        playerFootSteps = GetComponent<PlayerFootSteps>();
    }
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        bool isSprinting = Input.GetKey(KeyCode.LeftShift);
        bool isJumping = Input.GetKeyDown(KeyCode.Space) && Physics.Raycast(footPoint.position, Vector3.down, 3f);

        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSomoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);


            if (vertical == 1 && isSprinting)
            {
                anim.SetBool("Sprinting", true);
                speed = sprintModifier;
                playerFootSteps.step_Distance = 0.25f;
            }
            else
            { 
                anim.SetBool("Sprinting", false);
                speed = normalSpeed;
            }

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
           
                moveDir.y = -1f;
               
            
            characterController.Move(moveDir.normalized * speed * Time.deltaTime);
        }
       
       
        if (horizontal != 0 || vertical != 0)
        {
            if (!isSprinting)
            {
                playerFootSteps.step_Distance = 0.4f;
              

            }
            //  playerSound.SetActive(true);
            anim.SetBool("Walk", true);

        }
        else
        {
            anim.SetBool("Walk", false);
            anim.SetBool("Sprinting", false);
           // playerSound.SetActive(false);
        }

        Vector3 mouseWorldPos = Vector3.zero;
        Vector3 hitTransform = Vector3.zero;

        Vector2 centrePos = new Vector2(Screen.width / 2, Screen.height / 2);
        Ray ray = Camera.main.ScreenPointToRay(centrePos);
        if (Physics.Raycast(ray, out RaycastHit hit, 999f))
        {
            // debugTransform.position = hit.point;
            mouseWorldPos = hit.point;
            hitTransform = hit.point;
        }
        if (characterAiming.isAiming)
        {
            // aimVirtualCamera.gameObject.SetActive(true);

            Vector3 worldAimTarget = mouseWorldPos;
            worldAimTarget.y = transform.position.y;
            Vector3 aimDirection = (worldAimTarget - transform.position).normalized;
            transform.forward = Vector3.Lerp(transform.forward, aimDirection, Time.deltaTime * 20f);

         //   anim.SetLayerWeight(1, Mathf.Lerp(anim.GetLayerWeight(1), 1f ,Time.deltaTime * 10f));
        }
        else
        {
            // aimVirtualCamera.gameObject.SetActive(false);
        //    anim.SetLayerWeight(1, Mathf.Lerp(anim.GetLayerWeight(1), 0f, Time.deltaTime * 10f));
        }

        if (shoot && characterAiming.isAiming)
        {
            weaponCtrl.DoShoot();
            Vector3 aimDir = (mouseWorldPos - spawnBulletPos.position).normalized;
            Instantiate(bulletProjectile, spawnBulletPos.position, Quaternion.LookRotation(aimDir, Vector3.up));

            if (hitTransform != null)
            {
                //instantiat particle 
            }
            shoot = false;
        }
    }

    public void OnAim(InputValue value)
    {
        AimInput(value.isPressed);
    }

    private void AimInput(bool isPressed)
    {
        aim = isPressed;
    }

    public void OnShoot(InputValue value)
    {
        ShootInput(value.isPressed);
    }

    private void ShootInput(bool isPressed)
    {
        shoot = isPressed;
    }
}