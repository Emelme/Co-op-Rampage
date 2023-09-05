using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	public EnemyData ed;

	private GameObject player;

	public bool isPlayerDetected = false;

	private float timer;
	private float timerMax = 2f;

	private void Start()
	{
		player = FindAnyObjectByType<PlayerBehaviour>().gameObject;
	}

	private void Update()
	{
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
			transform.position = Vector2.MoveTowards(transform.position, new Vector2(player.transform.position.x, player.transform.position.y + 0.5f), ed.speed * Time.deltaTime); 
		}
	}
}
