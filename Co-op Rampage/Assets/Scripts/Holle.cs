using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Holle : MonoBehaviour
{
	private void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.CompareTag("Player") && Input.GetButtonDown("Ok"))
		{

		}
	}
}
