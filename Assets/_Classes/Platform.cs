using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour {

	public bool isOccupied = false;
	public int occupiedShipNumber;
	public int platformNumber;

	public void OccupyPlatform (int shipNumber) {
		occupiedShipNumber = shipNumber;
		Debug.Log (platformNumber + "Is occupied with ship №" + occupiedShipNumber);
	}

}
