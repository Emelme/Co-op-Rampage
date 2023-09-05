using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TriggersBehaviour : MonoBehaviour
{
	private PlayerAnimations pa;

	private Inventory iv;

	private void Start()
	{
		pa = GetComponent<PlayerAnimations>();
		iv = GetComponent<Inventory>();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Void"))
		{
			StartCoroutine(pa.FallingAnimation());
		}
	}
	
	private void OnTriggerStay2D(Collider2D collision)
	{
		if(collision.CompareTag("Weapon") && Input.GetButtonDown("Ok"))
		{
			iv.AddItem(collision.GetComponent<Weapon>().wd);
			Destroy(collision.gameObject);
		}

		if (collision.CompareTag("Item") && Input.GetButtonDown("Ok"))
		{
			iv.AddItem(collision.GetComponent<Item>().id);
			Destroy(collision.gameObject);
		}

		if (collision.CompareTag("Armor") && Input.GetButtonDown("Ok"))
		{
			iv.AddItem(collision.GetComponent<Armor>().ad);
			Destroy(collision.gameObject);
		}
	}
}
