using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RandomHolleSpawn : MonoBehaviour
{
	private Grid grid;

	public Vector2Int start;
	public Vector2Int end;

	private Tilemap tilemap;
	public Tile[] tiles = new Tile[2];

	public List<Vector3Int> allTiles;

	public GameObject triggerObject;
	public BoxCollider2D bc;

	private void Start()
	{
		grid = GetComponentInParent<Grid>();

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

		triggerObject = new GameObject("TriggerColliderOfHolle");

		triggerObject.AddComponent<BoxCollider2D>();

		bc = triggerObject.GetComponent<BoxCollider2D>();

		bc.isTrigger = true;
		bc.size = new(1f, 1f);
		bc.offset = Vector2.zero;

		Vector2 newPos = grid.CellToWorld(position);
		newPos += new Vector2(0.5f, 0.5f);
		triggerObject.transform.position = newPos;

		triggerObject.AddComponent<Holle>();
	}
}
