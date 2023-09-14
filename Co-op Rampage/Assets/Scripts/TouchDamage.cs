using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
		if (collision.CompareTag("Player") && !isDamageCoroutineRunning && !collision.gameObject.GetComponent<PlayerBehaviour>().isImmortal)
		{
			StartCoroutine(MakeTouchDamage(collision));
		}
	}

	private IEnumerator MakeTouchDamage(Collider2D col)
	{
		enemyTouchDamage = enemy.touchDamage;
		isDamageCoroutineRunning = true;
		col.gameObject.GetComponent<PlayerBehaviour>().StartImmortalReloading(1f);

		Health hp = FindAnyObjectByType<Health>();
		hp.SubHealth(enemyTouchDamage);

		Knockback kb = col.gameObject.GetComponent<Knockback>();
		kb.ApplyKnockback(transform.position, enemy.currentEd.knockback);

		yield return new WaitForSeconds(1f);

		isDamageCoroutineRunning = false;
	}
}
