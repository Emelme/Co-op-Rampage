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

	private SpriteRenderer sr;
	private Animator an;
	private CameraShake cs;

	public bool isReloading;
	public bool isAttacking;

	public LayerMask enemyLayer;

	private void Start()
	{
		gm = FindAnyObjectByType<GameManager>().GetComponent<GameManager>();
		pd = gm.playerDatas[(int)gm.charachterType];

		sr = GetComponent<SpriteRenderer>();
		an = GetComponent<Animator>();
		cs = FindAnyObjectByType<CameraShake>().GetComponent<CameraShake>();

		sr.sprite = wd.sprite;
		transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
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
			DetectColliders();
			cs.ShakeCamera(2f, 0.1f);
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
			collider.gameObject.SetActive(false);
		}
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Vector2 position = transform.position;
		Gizmos.DrawWireSphere(position, wd.range);
	}
}
