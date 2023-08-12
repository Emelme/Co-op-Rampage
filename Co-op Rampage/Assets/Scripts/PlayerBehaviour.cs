using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
	public PlayerData pd;

	public WeaponParent wp;

	private void Start()
	{
		wp = GetComponentInChildren<WeaponParent>();
	}

	private void Update()
	{
	}

	public Vector2 GetPointerInput()
	{
		Vector3 mousePosition = Input.mousePosition;
		mousePosition.z = Camera.main.nearClipPlane;
		return Camera.main.ScreenToWorldPoint(mousePosition);
	}
}
