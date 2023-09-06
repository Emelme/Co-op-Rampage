using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class EnemyData : ScriptableObject
{
	public enum EnemyType { knight, elf, wizard }

	public EnemyType enemyType;

	public RuntimeAnimatorController runtimeAnimatorController;

	public int hp;

	public float speed;
}
