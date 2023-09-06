using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
	private GameManager gm;
	private PlayerData pd;

	public Sprite hollowHeart;
	public Sprite halfHeart;
	public Sprite fullHeart;

	public GameObject[] hearts = new GameObject[10];
	private Image[] images = new Image[10];

	public bool isDead = false;

	private void Start()
	{
		for (int i = 0; i < hearts.Length; i++)
		{
			images[i] = hearts[i].GetComponent<Image>();
		}

		gm = FindAnyObjectByType<GameManager>().GetComponent<GameManager>();
		pd = gm.playerDatas[(int)gm.charachterType];

		if (pd.health > pd.maxHealth)
		{
			pd.health = pd.maxHealth;
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
		if (pd.health + value > pd.maxHealth)
		{
			pd.health = pd.maxHealth;
		}

		pd.health += value;
		ResetHearts();
	}

	public void SubHealth(int value)
	{
		if (pd.health - value < 1)
		{
			isDead = true;
		}

		pd.health -= value;
		ResetHearts();
	}

	public void AddMaxHealth(int value)
	{
		if (pd.maxHealth > 90)
		{
			value = 0;
		}

		pd.maxHealth += value;
		NewMaxHealth();
	}

	public void SubMaxHealth(int value)
	{
		if (pd.maxHealth < 20)
		{
			value = 0;
		}

		pd.maxHealth -= value;

		if (pd.health > pd.maxHealth)
		{
			pd.health = pd.maxHealth;
		}

		NewMaxHealth();
		ResetHearts();
	}

	public void ResetHearts()
	{
		int fullHearts = pd.health / 10;
		int halfHearts = (pd.health % 10) / 5;

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
			if (pd.maxHealth / 10 > i)
			{
				hearts[i].SetActive(true);
			}
			else
			{
				hearts[i].SetActive(false);
			}
		}

		Debug.Log(pd.maxHealth);
	}
}
