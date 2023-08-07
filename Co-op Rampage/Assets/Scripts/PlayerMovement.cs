using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	private GameManager gameManager;

	private Rigidbody2D rb;

	public float moveSpeed = 8f;

	public float maxSpeed;

	public float moveInputX;
	public float moveInputY;

	public float targetSpeedX;
	public float targetSpeedY;

	public float speedDifX;
	public float speedDifY;

	public float acceleration = 24f;
	public float decceleration = 32f;

	private void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		gameManager = FindObjectOfType<GameManager>();
	}

	private void Update()
	{
		moveInputX = Input.GetAxisRaw("Horizontal");
		moveInputY = Input.GetAxisRaw("Vertical");

		if (Input.GetKeyDown(KeyCode.R))
		{
			gameManager.RestartLevel();
		}
	}

	private void FixedUpdate()
	{
		targetSpeedX = moveInputX * moveSpeed;
		targetSpeedY = moveInputY * moveSpeed;

		speedDifX = targetSpeedX - rb.velocity.x;
		speedDifY = targetSpeedY - rb.velocity.y;

		float accelRateX = (Mathf.Abs(targetSpeedX) > 0.01f) ? acceleration : decceleration;
		float accelRateY = (Mathf.Abs(targetSpeedY) > 0.01f) ? acceleration : decceleration;

		float movementX = Mathf.Abs(speedDifX) * accelRateX * Mathf.Sign(speedDifX);
		float movementY = Mathf.Abs(speedDifY) * accelRateY * Mathf.Sign(speedDifY);

		Vector2 velocityChange = new Vector2(movementX, movementY);

		rb.AddForce(velocityChange);
	}
}
