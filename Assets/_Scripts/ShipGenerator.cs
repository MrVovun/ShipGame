using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipGenerator : MonoBehaviour {

	public int genTime = 10;
	public int nextShipNumber;

	[SerializeField]
	private Ship shipPrefab;

	List<Ship> ships = new List<Ship> ();

	void Start () {
		nextShipNumber = Random.Range (0, 9999);
		Debug.Log ("Starting ship number is " + nextShipNumber);
	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			StartCoroutine (GenerationCooldown ());
		}
	}

	IEnumerator GenerationCooldown () {
		while (true) {
			if (ships.Count < this.GetComponent<PlatformHolder> ().platformsNumber) {
				ships.Add (Instantiate (shipPrefab, new Vector2 (0, 0), Quaternion.identity));
			}
			yield return new WaitForSeconds (genTime);
			nextShipNumber = nextShipNumber + 1;
		}
	}

	public Ship GetFirstShipInList () {
		Ship ship = ships[0];
		return ship;
	}

	public void RemoveFirstShipInList () {
		ships.RemoveAt (0);
	}

}
