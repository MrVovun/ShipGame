using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTimers : MonoBehaviour {
	[SerializeField]
	private GameObject platformTimer;

	public GameObject SpawnPlatformTimer () {
		GameObject timer = Instantiate (platformTimer, new Vector2 (0, 0), Quaternion.identity);
		timer.transform.SetParent (transform);
		return timer;
	}

	public void Debugger () {
		Debug.Log ("Ti pidor");
	}
}
