using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
	public EnemyData ed;

	private GameObject player;

	public bool isPlayerDetected = false;

	private float timer;
	private float timerMax = 2f;

	public float distanceX;
	public float distanceY;

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
		distanceX = Mathf.Abs(transform.position.x - player.transform.position.x);
		distanceY = Mathf.Abs(transform.position.y - player.transform.position.y);

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

		if (isPlayerDetected && (distanceY > 1f || distanceX > 1.5f))
		{
			//transform.position = Vector2.MoveTowards(transform.position, new Vector2(player.transform.position.x, player.transform.position.y + 0.5f), ed.speed * Time.deltaTime); 

			Vector2 target = new(player.transform.position.x, player.transform.position.y + 0.7f);

			agent.isStopped = false;
			agent.SetDestination(target);
		}
		else if (distanceY < 1f || distanceX < 1.5f)
		{
			agent.isStopped = true;
		}
	}
}
