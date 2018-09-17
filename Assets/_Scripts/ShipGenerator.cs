using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipGenerator : MonoBehaviour {

	public int genTime = 10;
	public int maxShipNumber = 3;
	public int startingShipNumber;

	[SerializeField]
	private Ship shipPrefab;

	private void Awake () {
		startingShipNumber = Random.Range (0, 9999);
		Debug.Log ("Starting ship number is " + startingShipNumber);
	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			StartCoroutine (GenerateShip ());
		}
	}

	IEnumerator GenerateShip () {
		while (true) {
			yield return new WaitForSeconds (genTime);
			var shipNumber = startingShipNumber++;
			Instantiate (shipPrefab, new Vector2 (0, 0), Quaternion.identity);
			shipPrefab.thisShipNumber = shipNumber;
		}
	}
}
