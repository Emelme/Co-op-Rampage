using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerData : ScriptableObject
{
	public enum CharacterType { knight, elf, wizard }

	public CharacterType character;

	public int money = 0;

	public int maxInventorySlots = 2;

	public float speed = 8f;

	public int health = 50;

	public int maxHealth = 50;

	public int protection = 0;

	public int agility = 0;

	public int force = 0;

	public int accuracy = 100;

	public int crit = 0;

	public int useTime = 1;
}
