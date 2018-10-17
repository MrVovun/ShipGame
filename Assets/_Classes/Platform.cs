using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Platform : MonoBehaviour {

	public bool isOccupied = false;
	public int occupiedShipNumber;
	public int platformNumber;
	public float timer;
	public PlatformButton myButton;

	private ShipGenerator shipGen;
	private Ship ship;

	public void OccupyPlatform () {
		shipGen = GameObject.FindGameObjectWithTag ("GameController").GetComponent<ShipGenerator> ();
		ship = shipGen.GetFirstShipInList ();
		ship.myPlatform = this;
		ship.StartCoroutine ("MoveTo");
	}

	public void ShipGetOff () {
		Debug.Log ("Ship№" + occupiedShipNumber + " got off!");
		ship.StartCoroutine ("MoveToExit");
		occupiedShipNumber = 0;
		Debug.Log ("Cleaning up the place");
	}

	public void RemoveShipFromQueue () {
		shipGen.RemoveFirstShipInList ();
		occupiedShipNumber = ship.thisShipNumber;
		Debug.Log ("Platform №" + platformNumber + " is occupied with ship №" + occupiedShipNumber);
	}

	public IEnumerator StartTimer () {
		yield return new WaitForSeconds (timer);
		Debug.Log ("Platform " + platformNumber + " time is up");
	}

}
