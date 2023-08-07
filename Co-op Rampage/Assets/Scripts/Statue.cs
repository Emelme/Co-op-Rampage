using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statue : MonoBehaviour
{
	public Sprite[] sprites;
	private SpriteRenderer srTop;

	public bool isLava = true;
	public bool isWater = false;

	private Animator an;

	private void Start()
	{
		srTop = transform.Find("Top").GetComponent<SpriteRenderer>();
		srTop.sprite = sprites[Random.Range(0, 3)];

		an = transform.Find("Bottom").GetComponent<Animator>();
		an.SetBool("isLava", isLava);
		an.SetBool("isWater", isWater);
	}
}
