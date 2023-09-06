using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
	private GameManager gm;
	private PlayerData pd;

	private void Start()
	{
		gm = FindAnyObjectByType<GameManager>().GetComponent<GameManager>();
		pd = gm.playerDatas[(int)gm.charachterType];
	}

	private void Update()
	{
	}
}
