using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RandomHolleSpawn : MonoBehaviour
{
	private RandomFloor rf;

	private Vector2Int start;
	private Vector2Int end;

	private Tilemap tilemap;
	public Tile[] tiles = new Tile[2];

	public List<Vector3Int> allTiles;

	private void Start()
	{
		rf = GetComponent<RandomFloor>();

		start = rf.start;
		end = rf.end;

		tilemap = GetComponent<Tilemap>();

		for (int x = start.x; x <= end.x; x++)
		{
			for (int y = start.y; y >= end.y; y--)
			{
				allTiles.Add(new Vector3Int(x, y, 0));
			}
		}
	}
	public void CreateHolle()
	{
		Vector3Int position = allTiles[Random.Range(0, allTiles.Count)];

		tilemap.SetTile(position, tiles[Random.Range(0, tiles.Length)]);
	}
}
