using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class AnimationsBehaviour: MonoBehaviour
{
	private SpriteRenderer sr;
	private Animator an;
	private Rigidbody2D rb;
	private ParticleSystem ps;

	void Start()
	{
		sr = GetComponent<SpriteRenderer>();
		an = GetComponent<Animator>();
		rb = GetComponent<Rigidbody2D>();
		ps = GetComponentInChildren<ParticleSystem>();
	}

	void Update()
	{
		an.SetBool("isMoving", rb.velocity.x > 0.1f || rb.velocity.y > 0.1f || rb.velocity.x < -0.1f || rb.velocity.y < -0.1f);

		if (rb.velocity.x > 0.1f || rb.velocity.y > 0.1f || rb.velocity.x < -0.1f || rb.velocity.y < -0.1f)
		{
			ps.Play();

			if (rb.velocity.x > 0f)
			{ sr.flipX = false; }
			else if (rb.velocity.x < 0f)
			{ sr.flipX = true; }
		}
		else
		{
			ps.Stop();
		}
	}
}
