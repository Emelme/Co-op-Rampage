using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
	private CinemachineShake cs;

	public float knockbackForce = 30f;
	public float knockbackDuration = 0.2f;

	private Rigidbody2D rb;
	private float knockbackTimer;

	private void Start()
	{
		cs = FindAnyObjectByType<CinemachineShake>();

		rb = GetComponent<Rigidbody2D>();
	}

	public void ApplyKnockback(Vector2 target, float multiplier)
	{
		Vector2 direction = (Vector2)transform.position - target;

		rb.velocity = Vector2.zero;

		rb.AddForce(direction.normalized * knockbackForce * multiplier, ForceMode2D.Impulse);

		cs.ShakeCamera(2f, 0.25f);

		knockbackTimer = knockbackDuration;
	}

	private void Update()
	{
		if (knockbackTimer > 0f)
		{
			knockbackTimer -= Time.deltaTime;

			if (knockbackTimer <= 0f)
			{
				rb.velocity = Vector2.zero;
			}
		}
	}
}
