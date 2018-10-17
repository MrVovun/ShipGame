using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipGenerator : MonoBehaviour {

	public int genTime = 10;
	public int nextShipNumber;
	public GameObject exit;

	[SerializeField]
	private Ship shipPrefab;

	[SerializeField]
	private GameObject shipQueue;

	public List<Sprite> spriteList = new List<Sprite> ();
	public List<Ship> ships = new List<Ship> ();

	void Start () {
		nextShipNumber = 0;
	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			StartCoroutine (GenerationCooldown ());
		}
	}

	IEnumerator GenerationCooldown () {
		while (true) {
			if (ships.Count < this.GetComponent<PlatformHolder> ().platformsNumber) {
				Ship newShip = Instantiate (shipPrefab, new Vector2 (0, 0), Quaternion.identity);
				newShip.transform.parent = shipQueue.transform;
				ships.Add (newShip);
				nextShipNumber = nextShipNumber + 1;
			}
			yield return new WaitForSeconds (genTime);
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
