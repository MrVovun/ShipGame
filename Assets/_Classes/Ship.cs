using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour {

	public int thisShipNumber;

	private GameObject gameManager;

	private void Start () {
		gameManager = GameObject.FindGameObjectWithTag ("GameController");
		thisShipNumber = gameManager.GetComponent<ShipGenerator> ().nextShipNumber;
		Debug.Log ("Ship №" + thisShipNumber + " has arrived");
	}

}
