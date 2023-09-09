using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

[CreateAssetMenu]
public class WeaponData : ScriptableObject
{
	public new string name;

	public Sprite sprite;

	public int damage = 1;

	public float useTime = 1f;

	public int critDamage = 2;

	public int knockback = 1;

	public float range = 0.8f;

	public float distance = 1f;
}
