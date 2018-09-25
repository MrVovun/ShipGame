using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour {

	public int thisShipNumber;

	private GameObject gameManager;

	void Start () {
		gameManager = GameObject.FindGameObjectWithTag ("GameController");
		ShipGenerator shipGen = gameManager.GetComponent<ShipGenerator> ();
		thisShipNumber = shipGen.nextShipNumber;
		Debug.Log ("Ship №" + thisShipNumber + " has arrived");
		int randomIndex = Random.Range (0, shipGen.spriteList.Count);
		this.GetComponent<SpriteRenderer> ().sprite = shipGen.spriteList[randomIndex];
	}

}
