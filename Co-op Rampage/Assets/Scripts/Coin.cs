using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
	private Rigidbody2D rb;

	private float speed = 6f;

	private float timer = 0f;
	private float timerMax = 0.5f;

	private Vector2 randomPosition;

	private void Start()
	{
		rb = GetComponent<Rigidbody2D>();

		randomPosition = new(Random.Range(-3, 3), Random.Range(-3, 3));
	}
	private void Update()
	{
		if (timer <= timerMax)
		{
			rb.MovePosition((Vector2)transform.position + randomPosition * speed * Time.deltaTime);

			timer += Time.deltaTime;
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			collision.GetComponent<PlayerBehaviour>().money++;
			Destroy(gameObject);
		}
	}
}
