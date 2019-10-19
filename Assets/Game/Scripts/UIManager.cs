using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
	[SerializeField]
	private Text _ammoCountTxt;

	[SerializeField]
	private GameObject _coinImage;

	[SerializeField]
	private GameObject _buyWeaponText;

	[SerializeField]
	private GameObject _pickUpCoinText;

	public void UpdateAmmoCount(int currentAmmo)
	{
		_ammoCountTxt.text = "Ammo: " + currentAmmo;
	}

	public void EnableCoin()
	{
		_coinImage.SetActive(true);
	}

	public void DisableCoin()
	{
		_coinImage.SetActive(false);
	}

	public void EnableWeaponText()
	{
		_buyWeaponText.SetActive(true);
	}

	public void DisableWeaponText()
	{
		_buyWeaponText.SetActive(false);
	}
	
	public void EnablePickupCoinText()
	{
		_pickUpCoinText.SetActive(true);
	}

	public void DisablePickupCoinText()
	{
		_pickUpCoinText.SetActive(false);
	}
}
