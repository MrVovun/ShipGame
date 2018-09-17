using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour {

	public int thisShipNumber;

	private void Awake () {
		Debug.Log ("Ship №" + thisShipNumber + " has arrived");
	}

}
