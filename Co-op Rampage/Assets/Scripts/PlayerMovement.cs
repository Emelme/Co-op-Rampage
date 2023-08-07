using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	private Rigidbody2D rb;

	public ParticleSystem runParticle;

	public float moveSpeed = 8f;

	public float acceleration = 24f;
	public float decceleration = 32f;

	private void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	private void FixedUpdate()
	{
		float moveInputX = Input.GetAxisRaw("Horizontal");
		float moveInputY = Input.GetAxisRaw("Vertical");

		Vector2 movementInput = new Vector2(moveInputX, moveInputY).normalized;

		Vector2 currentVelocity = rb.velocity;
		Vector2 targetVelocity = movementInput * moveSpeed;

		Vector2 velocityDiff = targetVelocity - currentVelocity;

		float accelRate = (movementInput.magnitude > 0.01f) ? acceleration : decceleration;

		Vector2 force = velocityDiff * accelRate;

		rb.AddForce(force);
	}
}
