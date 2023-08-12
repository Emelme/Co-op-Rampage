/* 
   ------------------- Code Monkey -------------------
   
   Thank you for downloading this package.
   I hope you find it useful for your projects.
   If you have any questions, feel free to ask.
   Cheers!
   
              Visit us at unitycodemonkey.com
   --------------------------------------------------
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CinemachineShake : MonoBehaviour
{
	public static CinemachineShake Instance { get; private set; }

	private CinemachineVirtualCamera cinemachineVirtualCamera;
	private float shakeTimer;
	private float shakeTimerTotal;
	private float startingIntensity;

	private void Awake()
	{
		Instance = this;
		cinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();
		cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 0f;
	}

	public void ShakeCamera(float intensity, float time)
	{
		CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin = cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

		cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = intensity;

		startingIntensity = intensity;
		shakeTimerTotal = time;
		shakeTimer = time;
	}

	private void Update()
	{
		if (shakeTimer > 0)
		{
			shakeTimer -= Time.deltaTime;

			CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin = cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

			cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = Mathf.Lerp(startingIntensity, 0f, 1 - shakeTimer / shakeTimerTotal);
		}
	}
}
