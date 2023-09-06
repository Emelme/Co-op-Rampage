using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollower : MonoBehaviour
{
	public EnemyData ed;

	private GameObject player;

	public bool isPlayerDetected = false;

	private float timer;
	private float timerMax = 2f;

	public float distance;

	private NavMeshAgent agent;

	private void Start()
	{
		player = FindAnyObjectByType<PlayerBehaviour>().gameObject;

		agent = GetComponent<NavMeshAgent>();
		agent.updateRotation = false;
		agent.updateUpAxis = false;
		agent.speed = ed.speed;
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

		if (!isPlayerDetected && (Input.GetButtonDown("Horizontal") || Input.GetButtonDown("Vertical")))
		{
			isPlayerDetected = true;
		}

		if (isPlayerDetected)
		{
			Vector2 playerPosition = new(player.transform.position.x, player.transform.position.y);

			Vector2 direction = playerPosition - (Vector2)transform.position;

			Vector2 targetPosition = playerPosition - direction.normalized * 1f;

			agent.SetDestination(targetPosition);
		}
	}
}
