using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
	private PlayerBehaviour pb;

	public Sprite hollowHeart;
	public Sprite halfHeart;
	public Sprite fullHeart;

	public GameObject[] hearts = new GameObject[10];
	private Image[] images = new Image[10];

	public bool isDead = false;

	private void Start()
	{
		pb = FindAnyObjectByType<PlayerBehaviour>();

		for (int i = 0; i < hearts.Length; i++)
		{
			images[i] = hearts[i].GetComponent<Image>();
		}

		if (pb.health > pb.maxHealth)
		{
			pb.health = pb.maxHealth;
		}

		NewMaxHealth();
		ResetHearts();
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Z))
		{
			AddHealth(3);
		}

		if (Input.GetKeyDown(KeyCode.X))
		{
			SubHealth(3);
		}

		if (Input.GetKeyDown(KeyCode.N))
		{
			AddMaxHealth(10);
		}

		if (Input.GetKeyDown(KeyCode.M))
		{
			SubMaxHealth(10);
		}

		if(Input.GetKeyDown(KeyCode.B))
		{
			NewMaxHealth();
		}
	}

	public void AddHealth(int value)
	{
		if (pb.health + value > pb.maxHealth)
		{
			pb.health = pb.maxHealth;
		}

		pb.health += value;
		ResetHearts();
	}

	public void SubHealth(int value)
	{
		if (pb.health - value < 1)
		{
			isDead = true;
		}

		pb.health -= value;
		ResetHearts();
	}

	public void AddMaxHealth(int value)
	{
		if (pb.maxHealth > 90)
		{
			value = 0;
		}

		pb.maxHealth += value;
		NewMaxHealth();
		ResetHearts();
	}

	public void SubMaxHealth(int value)
	{
		if (pb.maxHealth < 20)
		{
			value = 0;
		}

		pb.maxHealth -= value;

		if (pb.health > pb.maxHealth)
		{
			pb.health = pb.maxHealth;
		}

		NewMaxHealth();
		ResetHearts();
	}

	public void ResetHearts()
	{
		int fullHearts = pb.health / 10;
		int halfHearts = (pb.health % 10) / 5;

		for (int i = 0; i < images.Length; i++)
		{
			if (i < fullHearts)
			{
				images[i].sprite = fullHeart;
			}
			else if (i < fullHearts + halfHearts)
			{
				images[i].sprite = halfHeart;
			}
			else
			{
				images[i].sprite = hollowHeart;
			}
		}
	}

	public void NewMaxHealth()
	{
		for (int i = 0; i < hearts.Length; i++)
		{
			if (pb.maxHealth / 10 > i)
			{
				hearts[i].SetActive(true);
			}
			else
			{
				hearts[i].SetActive(false);
			}
		}
	}
}
