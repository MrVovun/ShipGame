using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnButtons : MonoBehaviour {
	[SerializeField]
	private GameObject platformButton;
	[SerializeField]
	private GameObject discardButton;

	public GameObject SpawnDiscardButton () {
		GameObject dButton = Instantiate (discardButton, new Vector2 (0, 0), Quaternion.identity);
		dButton.transform.SetParent (transform);
		return dButton;
	}

	public GameObject Spawn () {
		GameObject myButton = Instantiate (platformButton, new Vector2 (0, 0), Quaternion.identity);
		myButton.transform.SetParent (transform);
		return myButton;
	}

}
