using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerTeleport : MonoBehaviour
{
	private Grid grid;

	public Vector3Int start;
	public Vector3Int end;

	private PlayerMovement playerMovement;

	private void Start()
	{
		grid = GetComponent<Grid>();

		TeleportPlayer();
	}

	public void TeleportPlayer()
	{
		GameObject player = FindAnyObjectByType<PlayerBehaviour>().gameObject;

		Vector2 newPos = grid.CellToWorld(new(Random.Range(start.x, end.x), Random.Range(start.y, end.y)));
		newPos += new Vector2(0.5f, 0.5f);

		player.transform.position = newPos;

		player.GetComponent<PlayerMovement>().FreezeMovement();

	}
}
