using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraShake : MonoBehaviour
{
	private CinemachineVirtualCamera cinemachineVirtualCamera;
	private CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin;

	private float timer;

	private void Start()
	{
		cinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();
		StopShake();
	}

	private void Update()
	{
		if (timer > 0f)
		{
			timer -= Time.deltaTime;

			if (timer <= 0f)
			{
				StopShake();
			}
		}
	}

	public void ShakeCamera(float shakeIntensity, float shakeTime)
	{
		cinemachineBasicMultiChannelPerlin = cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
		cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = shakeIntensity;

		timer = shakeTime;
	}

	public void StopShake()
	{
		cinemachineBasicMultiChannelPerlin = cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
		cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = 0f;

		timer = 0f;
	}
}
