using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponParent : MonoBehaviour
{
	public Vector3 mousePosition;

	private SpriteRenderer sr;
	private SpriteRenderer pSr;

	private void Start()
	{
		sr = GetComponentInChildren<SpriteRenderer>();
		pSr = GetComponentInParent<SpriteRenderer>();
	}

	private void Update()
	{
		mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		mousePosition.z = 0;

		Vector3 direction = (mousePosition - transform.position).normalized;
		float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

		if (direction.x > 0)
		{
			pSr.flipX = false;

			transform.localScale = new Vector2(transform.localScale.x, 1);
		}
		else
		{
			pSr.flipX = true;

			transform.localScale = new Vector2(transform.localScale.x, -1);
		}

		if (transform.eulerAngles.z > 0 && transform.eulerAngles.z < 180)
		{
			sr.sortingOrder = pSr.sortingOrder - 1;
		}
		else
		{
			sr.sortingOrder = pSr.sortingOrder + 1;
		}
	}
}