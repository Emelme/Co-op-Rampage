using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Statue : MonoBehaviour
{
	public Sprite[] sprites;
	private SpriteRenderer srTop;

	public bool isLava;
	public bool isWater;

	private Animator an;

	private void Start()
	{
		if (Random.value > 0.5f)
		{
			isLava = true;
			isWater = false;
		}
		else
		{
			isLava = false;
			isWater = true;
		}

		srTop = transform.Find("Top").GetComponent<SpriteRenderer>();
		srTop.sprite = sprites[Random.Range(0, 3)];

		an = transform.Find("Bottom").GetComponent<Animator>();
		an.SetBool("isLava", isLava);
		an.SetBool("isWater", isWater);
	}
}
