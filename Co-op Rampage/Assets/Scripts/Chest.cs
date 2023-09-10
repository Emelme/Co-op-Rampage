using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Chest : MonoBehaviour
{
	private Animator an;
	public BoxCollider2D bc;

	public bool isTriggered = false;

	private void Start()
	{
		an = GetComponent<Animator>();

		bc = gameObject.AddComponent<BoxCollider2D>();
		bc.isTrigger = true;
		bc.size = new Vector2(2.5f, 2.5f);
		bc.offset = Vector2.zero;
	}

	private void Update()
	{
		if (isTriggered && (Input.GetButtonDown("Ok") || Input.GetButtonUp("Ok")))
		{
			an.SetBool("isOpen", true);
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
			an.SetBool("isOpen", true);
		}
	}
}
