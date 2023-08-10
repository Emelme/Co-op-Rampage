using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations: MonoBehaviour
{
	private SpriteRenderer sr;
	private Animator an;
	private Rigidbody2D rb;

	void Start()
	{
		sr = GetComponent<SpriteRenderer>();
		an = GetComponent<Animator>();
		rb = GetComponent<Rigidbody2D>();
	}

	void Update()
	{
		an.SetBool("isMoving", rb.velocity.x > 0.1f || rb.velocity.y > 0.1f || rb.velocity.x < -0.1f || rb.velocity.y < -0.1f);

		if (rb.velocity.x > 0.1f || rb.velocity.y > 0.1f || rb.velocity.x < -0.1f || rb.velocity.y < -0.1f)
		{
			if (rb.velocity.x > 0f)
			{ sr.flipX = false; }
			else if (rb.velocity.x < 0f)
			{ sr.flipX = true; }
		}
	}
}
