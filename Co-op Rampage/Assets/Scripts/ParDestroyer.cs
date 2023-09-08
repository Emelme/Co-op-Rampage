using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParDestroyer : MonoBehaviour
{
    void Start()
    {
		StartCoroutine("DestroyParticle");
	}

	public IEnumerator DestroyParticle()
	{
		yield return new WaitForSeconds(2f);

		Destroy(gameObject);
	}
}
