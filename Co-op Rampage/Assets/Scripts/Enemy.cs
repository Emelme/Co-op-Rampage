using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	public EnemyData[] ed1;
	public EnemyData[] ed2;
	public EnemyData[] ed3;
	public EnemyData[] ed4;
	public EnemyData[] ed5;

	public int currentIndex = -1;
	public EnemyData currentEd;

	public int hp;
	public float speed;

	public int touchDamage;

	private GameManager gm;

	public Animator animator;

	public GameObject particle;
	private ParticleSystem ps;

	public GameObject coin;

	private void Start()
	{
		gm = FindAnyObjectByType<GameManager>();

		if (gm.levelNumber < 6)
		{
			currentIndex = Random.Range(0, ed1.Length);
			currentEd = ed1[currentIndex];

			hp = currentEd.hp;
			speed = currentEd.speed;
		}

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

		Destroy(gameObject);
	}
}
