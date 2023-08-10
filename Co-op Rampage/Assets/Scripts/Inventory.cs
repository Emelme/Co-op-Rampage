using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
	public PlayerData pd;

	public int activeWeaponSlot = 0;
	public int activeItemSlot = 0;

	public List<WeaponData> weaponInventory = new();
	public List<ItemData> itemInventory = new();

	private void Start()
	{
		for (int i = 0; i < pd.maxInventorySlots; i++)
		{
			weaponInventory.Insert(i, null);
			itemInventory.Insert(i, null);
		}
	}

	private void Update()
	{
		if (Input.GetButtonDown("Change Active Weapon Slot"))
		{
			ChangeActiveWeaponSlot();
		}

		if (Input.GetButtonDown("Change Active Item Slot"))
		{
			ChangeActiveItemSlot();
		}
	}

	public void AddItem(WeaponData wd)
	{
		if (weaponInventory[activeWeaponSlot] == null)
		{
			AddItemAt(activeWeaponSlot, wd);
		}
		else if (IsInventoryFull(weaponInventory))
		{
			AddItemAt(activeWeaponSlot, wd);
		}
		else
		{
			for (int i = 0; i < pd.maxInventorySlots; i++)
			{
				if (weaponInventory[i] == null)
				{
					AddItemAt(i, wd);
					break;
				}
			}
		}
	}

	public void AddItem(ItemData id)
	{
		if (itemInventory[activeItemSlot] == null)
		{
			AddItemAt(activeItemSlot, id);
		}
		else if (IsInventoryFull(itemInventory))
		{
			AddItemAt(activeItemSlot, id);
		}
		else
		{
			for (int i = 0; i < pd.maxInventorySlots; i++)
			{
				if (itemInventory[i] == null)
				{
					AddItemAt(i, id);
					break;
				}
			}
		}
	}

	public void AddItemAt(int slot, WeaponData wd)
	{
		if (weaponInventory[slot] != null)
		{
			Drop(slot, weaponInventory);

			weaponInventory[slot] = wd;
		}
		else
		{
			weaponInventory[slot] = wd;
		}
	}

	public void AddItemAt(int slot, ItemData id)
	{
		if (itemInventory[slot] != null)
		{
			Drop(slot, itemInventory);

			itemInventory[slot] = id;
		}
		else
		{
			itemInventory[slot] = id;
		}
	}

	public void Drop(int slot, List<WeaponData> list)
	{
		list[slot] = null;
	}

	public void Drop(int slot, List<ItemData> list)
	{
		list[slot] = null;
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
		activeWeaponSlot = (activeWeaponSlot + 1) % pd.maxInventorySlots;
	}

	public void ChangeActiveItemSlot()
	{
		activeItemSlot = (activeItemSlot + 1) % pd.maxInventorySlots;
	}
}
