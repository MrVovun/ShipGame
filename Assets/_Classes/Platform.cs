using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Platform : MonoBehaviour {

	public bool isOccupied = false;
	public int occupiedShipNumber;
	public int platformNumber;
	public PlatformButton myButton;

	public void OccupyPlatform () {
		Ship ship = GameObject.FindGameObjectWithTag ("GameController").GetComponent<ShipGenerator> ().GetFirstShipInList ();
		GameObject.FindGameObjectWithTag ("GameController").GetComponent<ShipGenerator> ().RemoveFirstShipInList ();
		occupiedShipNumber = ship.thisShipNumber;
		isOccupied = true;
		Debug.Log ("Platform №" + platformNumber + " is occupied with ship №" + occupiedShipNumber);
	}

	public void ShipGetOff () {
		Debug.Log ("Ship№" + occupiedShipNumber + " got off!");
		occupiedShipNumber = 0;
		isOccupied = false;
	}

	IEnumerator ShipOnPlatformCountodown () {
		yield return new WaitForSeconds (5);
		ShipGetOff ();
	}

}
