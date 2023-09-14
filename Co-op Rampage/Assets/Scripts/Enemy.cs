using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	public EnemySpawner es;

	public EnemyData currentEd;

	public int hp;
	public float speed;

	public int touchDamage;

	public Animator animator;

	public GameObject particle;
	private ParticleSystem ps;

	public GameObject coin;

	public GameObject medSlime;
	public GameObject smallSlime;

	private void Start()
	{
		es = FindAnyObjectByType<EnemySpawner>();

		hp = currentEd.hp;
		speed = currentEd.speed;

		touchDamage = currentEd.touchDamage;

		animator = GetComponent<Animator>();
		animator.runtimeAnimatorController = currentEd.runtimeAnimatorController;
	}

	private void Update()
	{
		if (hp <= 0)
		{
			Dead();
		}

		transform.SetPositionAndRotation(new(transform.position.x, transform.position.y, 0f), Quaternion.Euler(0f, 0f, 0f));
	}
	
	public void Dead()
	{
		particle = Instantiate(particle, transform.position, Quaternion.identity);

		ps = particle.GetComponent<ParticleSystem>();

		ps.Play();

		int money = Random.Range(currentEd.moneyMin, currentEd.moneyMax + 1);

		for(int i = 0; i < money; i++)
		{
			Instantiate(coin, transform.position, Quaternion.identity);
		}

		if (currentEd.enemyType == EnemyData.EnemyType.BigBrownSlime)
		{
			es.enemyAmount += 2;

			Instantiate(medSlime, new(transform.position.x + Random.Range(-0.5f, 0.5f), transform.position.y + Random.Range(-0.5f, 0.5f)), Quaternion.identity);
			Instantiate(medSlime, new(transform.position.x + Random.Range(-0.5f, 0.5f), transform.position.y + Random.Range(-0.5f, 0.5f)), Quaternion.identity);
		}
		else if (currentEd.enemyType == EnemyData.EnemyType.MediumBrownSlime)
		{
			es.enemyAmount += 2;

			Instantiate(smallSlime, new(transform.position.x + Random.Range(-0.5f, 0.5f), transform.position.y + Random.Range(-0.5f, 0.5f)), Quaternion.identity);
			Instantiate(smallSlime, new(transform.position.x + Random.Range(-0.5f, 0.5f), transform.position.y + Random.Range(-0.5f, 0.5f)), Quaternion.identity);
		}

		es.EnemyDead();

		Destroy(gameObject);
	}
}
