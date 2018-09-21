using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipGenerator : MonoBehaviour {

	public int genTime = 10;
	public int maxShipNumber;
	public int nextShipNumber;

	[SerializeField]
	private Ship shipPrefab;
	[SerializeField]
	private int i = 0;

	private void Start () {
		nextShipNumber = Random.Range (0, 9999);
		Debug.Log ("Starting ship number is " + nextShipNumber);
	}

	void Update () {
		maxShipNumber = this.GetComponent<PlatformHolder> ().platformsNumber;
		if (Input.GetKeyDown (KeyCode.Space)) {
			StartCoroutine (GenerationCooldown ());
		}
	}

	IEnumerator GenerationCooldown () {
		while (i < maxShipNumber) {
			Instantiate (shipPrefab, new Vector2 (0, 0), Quaternion.identity);
			yield return new WaitForSeconds (genTime);
			nextShipNumber = nextShipNumber + 1;
			i = i + 1;
		}
	}
}
