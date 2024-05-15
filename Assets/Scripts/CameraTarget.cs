using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CameraTarget : MonoBehaviour
{
    public static CameraTarget Instance { get; private set; }
    private CinemachineVirtualCamera virtualCamera;
    public CharacterSelector characterselector;
    public Transform dante;
    public Transform vergil;

    private float durationTimer;

    private void Awake()
    {
        Instance = this;

    }
    void Start()
    {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
    }
    void Update()
    {
        if (characterselector.isDante)
        {
            virtualCamera.Follow = dante;
        }
        else if (characterselector.isVergil)
        {
            virtualCamera.Follow = vergil;
        }
        if (durationTimer > 0)
        {
            durationTimer -= Time.deltaTime;
            if (durationTimer <= 0)
            {
                CinemachineBasicMultiChannelPerlin virtualCameraMovement = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
                virtualCameraMovement.m_AmplitudeGain = 0;
            }
        }

    }
    public void shakeCamera(float magnitude, float duration)
    {
        CinemachineBasicMultiChannelPerlin virtualCameraMovement = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        virtualCameraMovement.m_AmplitudeGain = magnitude;
        durationTimer = duration;
    }
}
