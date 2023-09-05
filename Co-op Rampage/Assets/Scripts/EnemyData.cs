using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class EnemyData : ScriptableObject
{
	public new string name;

	public Sprite sprite;

	public int hp;

	public float speed;
}
