using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Holle : MonoBehaviour
{
	private GameManager gm;

	public bool isTriggered = false;

	private void Start()
	{
		gm = FindAnyObjectByType<GameManager>().GetComponent<GameManager>();
	}

	private void Update()
	{
		if (isTriggered && (Input.GetButtonDown("Ok") || Input.GetButtonUp("Ok")))
		{
			gm.CreateNewLevel();
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			isTriggered = true;
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			isTriggered = false;
		}
	}

	private void OnTriggerStay2D(Collider2D collision)
	{
		if (isTriggered && collision.CompareTag("Player") && (Input.GetButtonDown("Ok") || Input.GetButtonUp("Ok")))
		{
			gm.CreateNewLevel();
		}
	}
}
