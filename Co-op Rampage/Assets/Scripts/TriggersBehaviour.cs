using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggersBehaviour : MonoBehaviour
{
	private Animator an;

	public bool isFalling = false;

	private void Start()
	{
		an = GetComponent<Animator>();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Void"))
		{
			StartCoroutine(FallingAnimation());
		}
	}

	private IEnumerator FallingAnimation()
	{
		yield return new WaitForSeconds(0.1f);

		isFalling = true;
		an.SetBool("isFalling", isFalling);
	}
}
