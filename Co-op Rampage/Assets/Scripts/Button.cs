using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
	public Sprite spriteUp;
	public Sprite spriteDown;

	private SpriteRenderer spriteRenderer;

	private GameManager gameManager;

	private void Start()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
		spriteRenderer.sprite = spriteUp;
		gameManager = FindAnyObjectByType<GameManager>();
	}
	public void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			spriteRenderer.sprite = spriteDown;

			gameManager.CreateNewLevel();
		}
	}

	public void OnTriggerExit2D(Collider2D collision)
	{
		
	}
}
