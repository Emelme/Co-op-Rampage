using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;

public class Weapon : MonoBehaviour
{
	public WeaponData wd;

	private SpriteRenderer sr;
	private Animator an;

	public bool isReloading;
	public bool isAttacking;

	private void Start()
	{
		sr = GetComponent<SpriteRenderer>();
		an = GetComponentInParent<Animator>();

		sr.sprite = wd.sprite;
		transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
	}

	private void Update()
	{
		if (Input.GetButtonDown("Attack"))
		{
			StartCoroutine(Attack());
		}
	}

	public IEnumerator Attack()
	{
		if (!isReloading)
		{
			isReloading = true;
			an.SetBool("isAttacking", true);
			isAttacking = true;
			yield return new WaitForEndOfFrame();
			an.SetBool("isAttacking", false);
			yield return new WaitForSeconds(wd.useTime);
			isReloading = false;
		}
	}

	public void ResetIsAttacking()
	{
		isAttacking = false;
	}
}
