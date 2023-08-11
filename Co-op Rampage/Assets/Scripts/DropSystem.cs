using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropSystem : MonoBehaviour, IDropHandler
{
	public void OnDrop(PointerEventData eventData)
	{
		GameObject dropped = eventData.pointerDrag;

		Inventory iv = FindObjectOfType<Inventory>().GetComponent<Inventory>();

		if (dropped.CompareTag("Slot1Weapon") && gameObject.CompareTag("Slot2Weapon") || dropped.CompareTag("Slot2Weapon") && gameObject.CompareTag("Slot1Weapon"))
		{
			iv.Swap(iv.weaponInventory, 0, 1);
		}

		if (dropped.CompareTag("Slot1Item") && gameObject.CompareTag("Slot2Item") || dropped.CompareTag("Slot2Item") && gameObject.CompareTag("Slot1Item"))
		{
			iv.Swap(iv.itemInventory, 0, 1);
		}
	}
}
