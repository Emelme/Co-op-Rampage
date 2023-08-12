using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations: MonoBehaviour
{
	private Animator an;
	private Rigidbody2D rb;

	public bool isFalling = false;

	void Start()
	{
		an = GetComponent<Animator>();
		rb = GetComponent<Rigidbody2D>();
	}

	void Update()
	{
		an.SetBool("isMoving", rb.velocity.x > 0.1f || rb.velocity.y > 0.1f || rb.velocity.x < -0.1f || rb.velocity.y < -0.1f);
	}

	public IEnumerator FallingAnimation()
	{
		yield return new WaitForSeconds(0.1f);

		isFalling = true;
		an.SetBool("isFalling", isFalling);
	}
}
