using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Statue : MonoBehaviour
{
	public Sprite[] sprites;
	private SpriteRenderer srTop;

	public bool isLava;
	public bool isWater;

	private Animator an;

	private Light2D li;

	public Color lava;
	public Color water;

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

		li = GetComponentInChildren<Light2D>();

		if (isLava)
		{
			li.color = lava;
		}
		else if (isWater)
		{
			li.color = water;
		}
	}
}
