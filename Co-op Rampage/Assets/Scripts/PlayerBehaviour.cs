using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEditor;

public class PlayerBehaviour : MonoBehaviour
{
	private GameManager gm;
	private PlayerData pd;

	public TextMeshProUGUI moneyText;

	public int maxHealth;
	public int health;

	public bool isDead;

	public bool isImmortal = false;

	public int money = 0;

	private void Start()
	{
		gm = FindAnyObjectByType<GameManager>().GetComponent<GameManager>();
		pd = gm.playerDatas[(int)gm.charachterType];

		maxHealth = pd.maxHealth;
		health = pd.health;
	}

	private void Update()
	{
		moneyText.SetText(Convert.ToString(money));

		if(isDead)
		{
			EditorApplication.isPlaying = false;
			Application.Quit();
		}
	}
}
