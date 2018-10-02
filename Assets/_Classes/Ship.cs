using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ship : MonoBehaviour {

	public int thisShipNumber;
	public float speed = 1.0f;
	public Platform myPlatform;
	public bool isGoodShip;

	private GameObject gameManager;
	private GameObject exit;
	private ShipGenerator shipGen;

	[SerializeField]
	private int turnRateFactor = 10;

	void Start () {
		transform.rotation = Quaternion.identity;
		gameManager = GameObject.FindGameObjectWithTag ("GameController");
		shipGen = gameManager.GetComponent<ShipGenerator> ();
		thisShipNumber = shipGen.nextShipNumber;
		Debug.Log ("Ship №" + thisShipNumber + " has arrived");
		int randomIndex = Random.Range (0, shipGen.spriteList.Count);
		this.GetComponentInChildren<SpriteRenderer> ().sprite = shipGen.spriteList[randomIndex];
		isGoodShip = (Random.value > 0.5f);
	}

	public IEnumerator MoveTo () {
		float moveSpeed = speed * Time.deltaTime;
		while (myPlatform.isOccupied == false) {
			DeactivateButtons ();
			Vector2 wereToMove = Camera.main.ScreenToWorldPoint (myPlatform.transform.position);
			transform.up = wereToMove - (Vector2) transform.position * turnRateFactor;
			transform.position = Vector2.MoveTowards (transform.position, myPlatform.transform.position, moveSpeed);
			if (transform.position == myPlatform.transform.position) {
				ActivateButtons ();
				transform.rotation = Quaternion.identity;
				myPlatform.isOccupied = true;
				myPlatform.RemoveShipFromQueue ();
				if (isGoodShip == true) {
					gameManager.GetComponent<PlayerStats> ().playerMoney = gameManager.GetComponent<PlayerStats> ().playerMoney + 100;
				} else {
					gameManager.GetComponent<PlayerStats> ().playerMoney = gameManager.GetComponent<PlayerStats> ().playerMoney - 100;
				}
			}
			yield return null;
		}
	}

	public IEnumerator MoveToExit () {
		float moveSpeed = speed * Time.deltaTime;
		while (true) {
			DeactivateButtons ();
			Vector2 mp = Camera.main.ScreenToWorldPoint (shipGen.exit.transform.position);
			transform.up = mp - (Vector2) transform.position * turnRateFactor;
			transform.position = Vector2.MoveTowards (transform.position, shipGen.exit.transform.position, moveSpeed);
			if (transform.position == shipGen.exit.transform.position) {
				ActivateButtons ();
				myPlatform.isOccupied = false;
				Destroy (gameObject);
			}
			yield return null;
		}
	}

	void DeactivateButtons () {
		GameObject[] buttons = GameObject.FindGameObjectsWithTag ("PlatformButton");
		foreach (GameObject platformButton in buttons) {
			platformButton.GetComponent<Button> ().interactable = false;
		}
	}

	void ActivateButtons () {
		GameObject[] buttons = GameObject.FindGameObjectsWithTag ("PlatformButton");
		foreach (GameObject platformButton in buttons) {
			platformButton.GetComponent<Button> ().interactable = true;
		}
	}

}
