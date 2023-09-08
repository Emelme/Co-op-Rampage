using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySlowTrigger : MonoBehaviour
{
	private GameManager gm;
	private PlayerData pd;

	private void Start()
	{
		gm = FindAnyObjectByType<GameManager>().GetComponent<GameManager>();
		pd = gm.playerDatas[(int)gm.charachterType];
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			pd.speed /= 2f;
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			pd.speed *= 2f; 
		}
	}
}
