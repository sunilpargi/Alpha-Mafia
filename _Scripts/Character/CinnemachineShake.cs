using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CinnemachineShake : MonoBehaviour
{
    public static CinnemachineShake instance { get; private set; }
    CinemachineVirtualCamera virtualCamera;

    private float shakeTimer;
    private float shakeTimerTotal;
    private float shake;
    private float startingIntensity = 0;

    void Awake()
    {
        instance = this;
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
    }


    public void ShakeCamera(float intensity, float time)
    {
        CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin =
            virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = intensity;

        startingIntensity = time;
        shakeTimer = time;
        shakeTimerTotal = time;
    }
    // Update is called once per frame
    void Update()
    {
        if(shakeTimer > 0)
            shakeTimer -= Time.deltaTime;
        
        if(shakeTimer < 0)
        {
            //Time over
            CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin =
            virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

            cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = Mathf.Lerp(startingIntensity, 0f, (1 - (shakeTimer / shakeTimerTotal))); ;
           

        }
    }
}
