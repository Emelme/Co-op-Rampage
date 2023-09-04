using UnityEngine;
using UnityEngine.Tilemaps;

public class RandomWall : MonoBehaviour
{
	public Vector2Int start;
	public Vector2Int end;

	public Tilemap tilemap;
	public Tile tileBase;
	public Tile[] tilesFlag = new Tile[4];
	public Tile tilePotion;

	private void Start()
	{
		tilemap = GetComponent<Tilemap>();

		for (int x = start.x; x <= end.x; x++)
		{
			Vector3Int tilePosition = new(x, start.y, 0);

			if (Random.value < 0.9f)
			{
				tilemap.SetTile(tilePosition, tileBase);
			}
			else if (Random.value < 0.9f)
			{
				Tile randomTile = tilesFlag[Random.Range(0, tilesFlag.Length)];
				tilemap.SetTile(tilePosition, randomTile);
			}
			else
			{
				tilemap.SetTile(tilePosition, tilePotion);
			}
		}
	}
}
