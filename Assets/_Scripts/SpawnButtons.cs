using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnButtons : MonoBehaviour {

	public GameObject button;

	public GameObject Spawn () {
		GameObject myButton = Instantiate (button, new Vector2 (0, 0), Quaternion.identity);
		myButton.transform.SetParent (transform);
		return myButton;
	}

}
