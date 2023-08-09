using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TriggersBehaviour : MonoBehaviour
{
	public PlayerData pd;

	private Inventory iv;

	private Animator an;

	public bool isFalling = false;

	private void Start()
	{
		an = GetComponent<Animator>();
		iv = GetComponent<Inventory>();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Void"))
		{
			StartCoroutine(FallingAnimation());
		}
	}

	private void OnTriggerStay2D(Collider2D collision)
	{
		if(collision.CompareTag("Weapon") && Input.GetButtonDown("Ok"))
		{
			iv.AddWeapon(collision.GetComponent<Weapon>().wd);
			Destroy(collision.gameObject);
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		
	}

	private IEnumerator FallingAnimation()
	{
		yield return new WaitForSeconds(0.1f);

		isFalling = true;
		an.SetBool("isFalling", isFalling);
	}
}
