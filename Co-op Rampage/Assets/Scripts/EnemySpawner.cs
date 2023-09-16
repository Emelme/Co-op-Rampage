using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Cinemachine.DocumentationSortingAttribute;

public class EnemySpawner : MonoBehaviour
{
	public Vector2Int[] start;
	public Vector2Int[] end;

	public List<Vector2Int> allPosition;

	public int enemyAmount = 0;

	private GameManager gm;

	private void Start()
	{
		gm = FindAnyObjectByType<GameManager>();

		for (int i = 0; i < start.Length; i++)
		{
			for (int x = start[i].x; x <= end[i].x; x++)
			{
				for (int y = start[i].y; y >= end[i].y; y--)
				{
					allPosition.Add(new Vector2Int(x, y));
				}
			}
		}

		SpawnEnemys(allPosition, gm.levelNumber);
	}

	public void SpawnEnemys(List<Vector2Int> list, int levelNumber)
	{
		if (levelNumber >= 1 && levelNumber <= 5)
		{
			int enemyAmountInMethod = Random.Range(1, 5);
			Debug.Log(enemyAmountInMethod);

			for (int i = 0; i <= enemyAmountInMethod; i++)
			{
				int index = Random.Range(0, list.Count);
				Vector2Int position = list[index];
				Instantiate(gm.enemy1[Random.Range(0, gm.enemy1.Length)], new Vector3(position.x + 0.5f, position.y + 0.5f, 0f), transform.rotation);
				Debug.Log(enemyAmount);
				enemyAmount++;
				Debug.Log("+++++++++++++++++++" + enemyAmount);
				list.RemoveAt(index);
			}
		}
		else if (levelNumber >= 7 && levelNumber <= 11)
		{
			int enemyAmountInMethod = Random.Range(2, 7);

			for (int i = 0; i <= enemyAmountInMethod; i++)
			{
				int index = Random.Range(0, list.Count);
				Vector2Int position = list[index];
				Instantiate(gm.enemy2[Random.Range(0, gm.enemy2.Length)], new Vector3(position.x + 0.5f, position.y + 0.5f, 0f), Quaternion.identity);
				enemyAmount++;
				list.RemoveAt(index);
			}
		}
		else if (levelNumber >= 13 && levelNumber <= 17)
		{
			int enemyAmountInMethod = Random.Range(4, 9);

			for (int i = 0; i <= enemyAmountInMethod; i++)
			{
				int index = Random.Range(0, list.Count);
				Vector2Int position = list[index];
				Instantiate(gm.enemy3[Random.Range(0, gm.enemy3.Length)], new Vector3(position.x + 0.5f, position.y + 0.5f, 0f), Quaternion.identity);
				enemyAmount++;
				list.RemoveAt(index);
			}
		}
		else if (levelNumber >= 19 && levelNumber <= 23)
		{
			int enemyAmountInMethod = Random.Range(6, 11);

			for (int i = 0; i <= enemyAmountInMethod; i++)
			{
				int index = Random.Range(0, list.Count);
				Vector2Int position = list[index];
				Instantiate(gm.enemy4[Random.Range(0, gm.enemy4.Length)], new Vector3(position.x + 0.5f, position.y + 0.5f, 0f), Quaternion.identity);
				enemyAmount++;
				list.RemoveAt(index);
			}
		}
		else if (levelNumber >= 25 && levelNumber <= 29)
		{
			int enemyAmountInMethod = Random.Range(8, 13);

			for (int i = 0; i <= enemyAmountInMethod; i++)
			{
				int index = Random.Range(0, list.Count);
				Vector2Int position = list[index];
				Instantiate(gm.enemy5[Random.Range(0, gm.enemy5.Length)], new Vector3(position.x + 0.5f, position.y + 0.5f, 0f), Quaternion.identity);
				enemyAmount++;
				list.RemoveAt(index);
			}
		}
	}

	public void EnemyDead()
	{
		enemyAmount--;

		if (enemyAmount <= 0)
		{
			RandomHolleSpawn rhs = GetComponentInChildren<RandomHolleSpawn>();
			StartCoroutine(rhs.CreateHolle());
		}
	}
}
