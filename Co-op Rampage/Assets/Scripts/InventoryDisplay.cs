using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryDisplay : MonoBehaviour
{
	private Inventory iv;

	public GameObject slot1W;
	public GameObject slot2W;
	private Animator an1W;
	private Animator an2W;

	public GameObject imageSlot1W;
	public GameObject imageSlot2W;
	private Image im1W;
	private Image im2W;

	public GameObject slot1I;
	public GameObject slot2I;
	private Animator an1I;
	private Animator an2I;

	public GameObject imageSlot1I;
	public GameObject imageSlot2I;
	private Image im1I;
	private Image im2I;

	public GameObject slotA;
	private Animator anA;
	public GameObject imageSlotA;
	private Image imA;
	public GameObject armorLogo;
	private Animator anAL;

	private void Start()
	{
		iv = FindObjectOfType<Inventory>().GetComponent<Inventory>();

		an1W = slot1W.GetComponent<Animator>();
		an2W = slot2W.GetComponent<Animator>();

		im1W = imageSlot1W.GetComponent<Image>();
		im2W = imageSlot2W.GetComponent<Image>();

		im1W.enabled = false;
		im2W.enabled = false;

		an1I = slot1I.GetComponent<Animator>();
		an2I = slot2I.GetComponent<Animator>();

		im1I = imageSlot1I.GetComponent<Image>();
		im2I = imageSlot2I.GetComponent<Image>();

		im1I.enabled = false;
		im2I.enabled = false;

		anA = slotA.GetComponent<Animator>();
		imA = imageSlotA.GetComponent<Image>();
		anAL = armorLogo.GetComponent<Animator>();
	}

	private void Update()
	{
		an1W.SetInteger("Active Slot", iv.activeWeaponSlot);
		an2W.SetInteger("Active Slot", iv.activeWeaponSlot);

		if (iv.weaponInventory[0] != null)
		{
			im1W.enabled = true;
			im1W.sprite = iv.weaponInventory[0].sprite;
		}
		else
		{
			im1W.enabled = false;
		}

		if (iv.weaponInventory[1] != null)
		{
			im2W.enabled = true;
			im2W.sprite = iv.weaponInventory[1].sprite;
		}
		else
		{
			im2W.enabled = false;
		} 

		an1I.SetInteger("Active Slot Item", iv.activeItemSlot);
		an2I.SetInteger("Active Slot Item", iv.activeItemSlot);

		if (iv.itemInventory[0] != null)
		{
			im1I.enabled = true;
			im1I.sprite = iv.itemInventory[0].sprite;
		}
		else
		{
			im1I.enabled = false;
		}

		if (iv.itemInventory[1] != null)
		{
			im2I.enabled = true;
			im2I.sprite = iv.itemInventory[1].sprite;
		}
		else
		{
			im2I.enabled = false;
		}

		anA.SetBool("IsArmorSlotFull", iv.IsInventoryFull(iv.armorInventory));
		anAL.SetBool("IsArmorSlotFull", iv.IsInventoryFull(iv.armorInventory));

		if (iv.IsInventoryFull(iv.armorInventory))
		{
			imageSlotA.SetActive(true);
			imA.sprite = iv.armorInventory.sprite;
			armorLogo.SetActive(false);
		}
		else
		{
			imageSlotA.SetActive(false);
		}
	}
}
