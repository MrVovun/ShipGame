using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour {

	public int playerMoney = 100;
	[SerializeField]
	private Text moneyDisplay;

	private void Update () {
		moneyDisplay.text = "Money " + playerMoney;
	}

}
