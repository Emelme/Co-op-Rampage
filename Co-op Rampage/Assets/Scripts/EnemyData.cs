using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class EnemyData : ScriptableObject
{
	public enum EnemyType { GreenSlime,  }

	public EnemyType enemyType;

	public RuntimeAnimatorController runtimeAnimatorController;

	public int hp;

	public float speed;

	public int moneyMax;

	public int moneyMin;

	public int touchDamage;

	public float knockback = 1f;
}
