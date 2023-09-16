using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	private GameManager gm;
	private PlayerData pd;

	private Rigidbody2D rb;

	public float acceleration = 24f;
	public float decceleration = 32f;

	public bool isFreeze = false;
	private Vector2 positionWas;

	private float timerMax = 1f;
	private float timer = 2f;

	private void Start()
	{
		gm = FindAnyObjectByType<GameManager>().GetComponent<GameManager>();
		pd = gm.playerDatas[(int)gm.charachterType];

		rb = GetComponent<Rigidbody2D>();
	}

	private void Update()
	{
		timer += Time.deltaTime;

		if (timer < timerMax)
		{
			isFreeze = true;
		}
		else
		{
			isFreeze = false;
		}

		if (isFreeze)
		{


			rb.velocity = Vector3.zero;
			transform.position = positionWas;
		}
	}

	private void FixedUpdate()
	{
		float moveInputX = Input.GetAxisRaw("Horizontal");
		float moveInputY = Input.GetAxisRaw("Vertical");

		Vector2 movementInput = new Vector2(moveInputX, moveInputY).normalized;

		float moveSpeed = pd.speed;

		Vector2 currentVelocity = rb.velocity;
		Vector2 targetVelocity = movementInput * moveSpeed;

		Vector2 velocityDiff = targetVelocity - currentVelocity;

		float accelRate = (movementInput.magnitude > 0.01f) ? acceleration : decceleration;

		Vector2 force = velocityDiff * accelRate;

		rb.AddForce(force);
	}

	public void FreezeMovement()
	{
		timer = 0f;
		positionWas = transform.position;
	}
}
