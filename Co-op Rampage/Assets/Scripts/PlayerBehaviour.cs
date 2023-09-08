using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
	private GameManager gm;
	private PlayerData pd;

	public int maxHealth;
	public int health;

	private void Start()
	{
		gm = FindAnyObjectByType<GameManager>().GetComponent<GameManager>();
		pd = gm.playerDatas[(int)gm.charachterType];

		maxHealth = pd.maxHealth;
		health = pd.health;
	}

	private void Update()
	{
	}
}
