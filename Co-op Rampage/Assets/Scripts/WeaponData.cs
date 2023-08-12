using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

[CreateAssetMenu]
public class WeaponData : ScriptableObject
{
	public new string name;

	public Sprite sprite;

	public int damage;

	public float useTime;

	public int critChance;

	public int critDamage;

	public int knockdown;

	public Vector2 range;

	public float radius;
}
