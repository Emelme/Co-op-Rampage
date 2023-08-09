using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
	public PlayerData pd;

	public int activeWeaponSlot = 0;

	public List<WeaponData> weaponInventory = new();
	public List<ItemData> itemInventory = new();

	private void Start()
	{
		for (int i = 0; i < pd.maxInventorySlots; i++)
		{
			weaponInventory.Insert(i, null);
		}
	}

	private void Update()
	{
		if (Input.GetButtonDown("Change Active Weapon Slot"))
		{
			ChangeActiveWeaponSlot();
		}
	}

	public void AddWeapon(WeaponData wd)
	{
		if (weaponInventory[activeWeaponSlot] == null)
		{
			AddWeaponAt(activeWeaponSlot, wd);
		}
		else if (IsInventoryFull(weaponInventory))
		{
			AddWeaponAt(activeWeaponSlot, wd);
		}
		else
		{
			for (int i = 0; i < pd.maxInventorySlots; i++)
			{
				if (weaponInventory[i] == null)
				{
					AddWeaponAt(i, wd);
					break;
				}
			}
		}
	}

	public void AddWeaponAt(int slot, WeaponData wd)
	{
		if (weaponInventory[slot] != null)
		{
			Drop(slot);

			weaponInventory[slot] = wd;
		}
		else
		{
			weaponInventory[slot] = wd;
		}
	}

	public void Drop(int slot)
	{
		weaponInventory[slot] = null;
	}

	public bool IsInventoryFull(List<WeaponData> list)
	{
		if (list.Count < pd.maxInventorySlots)
		{
			return list.Count < pd.maxInventorySlots;
		}
		else
		{
			int fullSlots = 0;

			for (int i = 0; i < pd.maxInventorySlots; i++)
			{
				if (list[i] != null)
				{ fullSlots++; }
			}

			return fullSlots >= pd.maxInventorySlots;
		}
	}

	public bool IsInventoryFull(List<ItemData> list)
	{
		if (list.Count < pd.maxInventorySlots)
		{
			return list.Count < pd.maxInventorySlots;
		}
		else
		{
			int fullSlots = 0;

			for (int i = 0; i < pd.maxInventorySlots; i++)
			{
				if (list[i] != null)
				{ fullSlots++; }
			}

			return fullSlots >= pd.maxInventorySlots;
		}
	}

	public void ChangeActiveWeaponSlot()
	{
		activeWeaponSlot += 1;

		if (activeWeaponSlot == pd.maxInventorySlots)
		{
			activeWeaponSlot = 0;
		}
	}
}
