using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchDamage : MonoBehaviour
{
	public GameObject enemyObject;

	public Enemy enemy;

	public int enemyTouchDamage;

	public bool isDamageCoroutineRunning = false;

	private void Start()
	{
		enemy = enemyObject.GetComponent<Enemy>();
	}

	private void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.CompareTag("Player") && !isDamageCoroutineRunning)
		{
			enemyTouchDamage = enemy.touchDamage;
			StartCoroutine(MakeTouchDamage());
		}
	}

	private IEnumerator MakeTouchDamage()
	{
		isDamageCoroutineRunning = true;

		Health hp = FindAnyObjectByType<Health>();
		hp.SubHealth(enemyTouchDamage);

		yield return new WaitForSeconds(1f);

		isDamageCoroutineRunning = false;
	}
}
