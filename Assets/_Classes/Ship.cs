using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour {

	public int thisShipNumber;
	public float speed = 1.0f;
	public Platform myPlatform;

	private GameObject gameManager;
	private GameObject exit;
	private ShipGenerator shipGen;

	void Start () {
		gameManager = GameObject.FindGameObjectWithTag ("GameController");
		shipGen = gameManager.GetComponent<ShipGenerator> ();
		thisShipNumber = shipGen.nextShipNumber;
		Debug.Log ("Ship №" + thisShipNumber + " has arrived");
		int randomIndex = Random.Range (0, shipGen.spriteList.Count);
		this.GetComponent<SpriteRenderer> ().sprite = shipGen.spriteList[randomIndex];
	}

	public IEnumerator MoveTo () {
		float moveSpeed = speed * Time.deltaTime;
		while (myPlatform.isOccupied == false) {
			//look at platform
			transform.position = Vector2.MoveTowards (transform.position, myPlatform.transform.position, moveSpeed);
			if (transform.position == myPlatform.transform.position) {
				myPlatform.isOccupied = true;
				myPlatform.RemoveShipFromQueue ();
				myPlatform.StartCoroutine ("ShipOnPlatformCountodown");
			}
			yield return null;
		}
	}

	public IEnumerator MoveToExit () {
		float moveSpeed = speed * Time.deltaTime;
		while (true) {
			//look at exit
			transform.position = Vector2.MoveTowards (transform.position, shipGen.exit.transform.position, moveSpeed);
			if (transform.position == shipGen.exit.transform.position) {
				Destroy (gameObject);
			}
			yield return null;
		}
	}

}
