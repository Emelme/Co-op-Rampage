using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;

public class Weapon : MonoBehaviour
{
	public WeaponData wd;

	private GameManager gm;
	private PlayerData pd;
	private Rigidbody2D player;
	public float knockbackStrength = 16f;

	private SpriteRenderer sr;
	private Animator an;
	private CinemachineShake cs;

	public bool isReloading;
	public bool isAttacking;

	public LayerMask enemyLayer;

	private void Start()
	{
		gm = FindAnyObjectByType<GameManager>().GetComponent<GameManager>();
		pd = gm.playerDatas[(int)gm.charachterType];
		player = GetComponentInParent<Rigidbody2D>();

		sr = GetComponent<SpriteRenderer>();
		an = GetComponent<Animator>();
		cs = FindAnyObjectByType<CinemachineShake>().GetComponent<CinemachineShake>();

		sr.sprite = wd.sprite;
		transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
	}

	private void Update()
	{
		if (Input.GetButton("Attack"))
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
			DetectColliders();
			cs.ShakeCamera(0.5f, 0.25f);
			yield return new WaitForEndOfFrame();
			an.SetBool("isAttacking", false);
			yield return new WaitForSeconds(wd.useTime * pd.useTime);
			isReloading = false;
		}
	}

	public void ResetIsAttacking()
	{
		isAttacking = false;
	}

	public void DetectColliders()
	{
		foreach (Collider2D collider in Physics2D.OverlapCircleAll(new Vector2(pd.distance * wd.distance * transform.localPosition.x + transform.position.x, transform.position.y), wd.range, enemyLayer))
		{
			Enemy enemy = collider.GetComponentInParent<Enemy>();

			if (Random.Range(1, 101) <= pd.accuracy)
			{
				enemy.hp -= wd.damage * pd.force * Crit();
				StartCoroutine(Knockback(collider));
			}
			else
			{
				Miss();
			}
		}
	}

	public IEnumerator Knockback(Collider2D col)
	{
		Vector2 direction = (col.transform.position - player.gameObject.transform.position).normalized;
		col.gameObject.transform.parent.gameObject.GetComponent<Rigidbody2D>().AddForce(direction * knockbackStrength * wd.knockback, ForceMode2D.Impulse);
		yield return new WaitForSeconds(0.2f);
		col.gameObject.transform.parent.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
	}

	public int Crit()
	{
		if (Random.Range(1, 101) <= pd.crit)
		{
			return wd.critDamage;
		}
		else
		{
			return 1;
		}
	}

	public void Miss()
	{

	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Vector2 position = transform.position;
		Gizmos.DrawWireSphere(position, wd.range);
	}
}
