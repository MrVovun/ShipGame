using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlatformButton : MonoBehaviour {

	public Platform myPlatform;

	private void Start () {
		myPlatform.myButton = this;
		this.GetComponentInChildren<Text> ().text = ("Platform №" + myPlatform.platformNumber);
	}

	public void GetThisShipToMyPlatform () {
		if (myPlatform.isOccupied == false) {
			myPlatform.OccupyPlatform ();
		} else {
			myPlatform.ShipGetOff ();
		}
	}

}
