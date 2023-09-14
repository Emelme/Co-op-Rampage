using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollower : MonoBehaviour
{
	private Enemy en;

	private GameObject player;

	public bool isPlayerDetected = false;

	private float timer;
	private readonly float timerMax = 2f;

	public float distance;

	private NavMeshAgent agent;

	private void Start()
	{
		player = FindAnyObjectByType<PlayerBehaviour>().gameObject;

		agent = GetComponent<NavMeshAgent>();
		agent.updateRotation = false;
		agent.updateUpAxis = false;
		en = GetComponent<Enemy>();
	}

	private void Update()
	{
		distance = Vector2.Distance(transform.position, player.transform.position);

		if (!isPlayerDetected)
		{
			timer += Time.deltaTime;

			if (timer > timerMax)
			{
				isPlayerDetected = true;
			}
		}

		if (distance < 1f || !isPlayerDetected)
		{
			en.animator.SetBool("isRunning", false);
		}
		else if (distance > 1f && isPlayerDetected)
		{
			en.animator.SetBool("isRunning", true);
		}

		if (!isPlayerDetected && (Input.GetButtonDown("Horizontal") || Input.GetButtonDown("Vertical")))
		{
			isPlayerDetected = true;
		}

		if (isPlayerDetected)
		{
			Vector2 playerPosition = new(player.transform.position.x, player.transform.position.y);

			Vector2 direction = playerPosition - (Vector2)transform.position;

			Vector2 targetPosition = playerPosition - direction.normalized * 0.75f;

			agent.speed = en.speed;

			agent.SetDestination(targetPosition);
		}
	}
}
