using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Animations;

[CreateAssetMenu]
public class PlayerData : ScriptableObject
{
	public enum CharacterType { knight, elf, wizard }

	public CharacterType character;

	public RuntimeAnimatorController runtimeAnimatorController;

	public int maxInventorySlots = 2;

	public float speed = 8f;

	public int health = 50;

	public int maxHealth = 50;

	public int protection = 1;

	public int agility = 0;

	public int force = 1;

	public int accuracy = 100;

	public int crit = 10;

	public float distance = 1f;

	public float useTime = 1f;
}
