using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Cinemachine.DocumentationSortingAttribute;

public class EnemySpawner : MonoBehaviour
{
	public Vector2Int[] start;
	public Vector2Int[] end;

	public List<Vector2Int> allPosition;

	public GameObject[] enemy1;
	public GameObject[] enemy2;
	public GameObject[] enemy3;
	public GameObject[] enemy4;
	public GameObject[] enemy5;

	public int enemyAmount = 0;

	private GameManager gameManager;

	private void Start()
	{
		gameManager = FindAnyObjectByType<GameManager>();

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

		SpawnEnemys(allPosition, gameManager.levelNumber);
	}

	public void SpawnEnemys(List<Vector2Int> list, int levelNumber)
	{
		if (levelNumber >= 1 && levelNumber <= 5)
		{
			enemyAmount = Random.Range(1, 5);

			for (int i = 0; i <= enemyAmount; i++)
			{
				int index = Random.Range(0, allPosition.Count);
				Vector2Int position = allPosition[index];
				Instantiate(enemy1[Random.Range(0, enemy1.Length)], new Vector3(position.x + 0.5f, position.y + 0.5f, 0f), Quaternion.identity);
				allPosition.RemoveAt(index);
			}
		}
		else if (levelNumber >= 7 && levelNumber <= 11)
		{
			enemyAmount = Random.Range(2, 7);

			for (int i = 0; i <= enemyAmount; i++)
			{
				int index = Random.Range(0, allPosition.Count);
				Vector2Int position = allPosition[index];
				Instantiate(enemy2[Random.Range(0, enemy2.Length)], new Vector3(position.x + 0.5f, position.y + 0.5f, 0f), Quaternion.identity);
				allPosition.RemoveAt(index);
			}
		}
		else if (levelNumber >= 13 && levelNumber <= 17)
		{
			enemyAmount = Random.Range(4, 9);

			for (int i = 0; i <= enemyAmount; i++)
			{
				int index = Random.Range(0, allPosition.Count);
				Vector2Int position = allPosition[index];
				Instantiate(enemy3[Random.Range(0, enemy3.Length)], new Vector3(position.x + 0.5f, position.y + 0.5f, 0f), Quaternion.identity);
				allPosition.RemoveAt(index);
			}
		}
		else if (levelNumber >= 19 && levelNumber <= 23)
		{
			enemyAmount = Random.Range(6, 11);

			for (int i = 0; i <= enemyAmount; i++)
			{
				int index = Random.Range(0, allPosition.Count);
				Vector2Int position = allPosition[index];
				Instantiate(enemy4[Random.Range(0, enemy4.Length)], new Vector3(position.x + 0.5f, position.y + 0.5f, 0f), Quaternion.identity);
				allPosition.RemoveAt(index);
			}
		}
		else if (levelNumber >= 25 && levelNumber <= 29)
		{
			enemyAmount = Random.Range(8, 13);

			for (int i = 0; i <= enemyAmount; i++)
			{
				int index = Random.Range(0, allPosition.Count);
				Vector2Int position = allPosition[index];
				Instantiate(enemy5[Random.Range(0, enemy5.Length)], new Vector3(position.x + 0.5f, position.y + 0.5f, 0f), Quaternion.identity);
				allPosition.RemoveAt(index);
			}
		}
	}

	public void enemyDead()
	{
		enemyAmount--;

		if (enemyAmount == 0)
		{
			RandomHolleSpawn rhs = GetComponentInChildren<RandomHolleSpawn>();
			rhs.CreateHolle();
		}
	}
}
