using UnityEngine;
using UnityEngine.Tilemaps;

public class RandomFloor : MonoBehaviour
{
	public Vector2Int start;
	public Vector2Int end;

	public Tilemap tilemap;
	public Tile tileBase;
	public Tile[] tilesCollapse = new Tile[3];

	private void Start()
	{
		tilemap = GetComponent<Tilemap>();

		for (int x = start.x; x <= end.x; x++)
		{
			for (int y = start.y; y >= end.y; y--)
			{
				Vector3Int tilePosition = new(x, y, 0);

				if (Random.value < 0.9f)
				{
					tilemap.SetTile(tilePosition, tileBase);
				}
				else
				{
					Tile randomTile = tilesCollapse[Random.Range(0, tilesCollapse.Length)];
					tilemap.SetTile(tilePosition, randomTile);
				}
			}
		}
	}
}
