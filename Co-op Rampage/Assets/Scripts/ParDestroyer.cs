using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class ParDestroyer : MonoBehaviour
{
	private Light2D light2D;

	public float start;
	private float end = 0f;
	
	public float lifeTime = 0.5f;
	public float timer;

    void Start()
    {
		light2D = GetComponentInChildren<Light2D>();
		start = light2D.intensity;

		StartCoroutine("DestroyParticle");
	}

	private void Update()
	{
		timer += Time.deltaTime;

		float progress = Mathf.Clamp01(timer / lifeTime);

		light2D.intensity = Mathf.Lerp(start, end, progress);
	}

	public IEnumerator DestroyParticle()
	{
		yield return new WaitForSeconds(2f);

		Destroy(gameObject);
	}
}
