using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformHolder : MonoBehaviour {

	public int platformsNumber;

	[SerializeField]
	private Platform platformPrefab;

	private void Start () {
		for (int i = 0; i < platformsNumber; i++) {
			SpawnPlatform ();
		}
	}

	private void Update () {
		if (Input.GetKeyDown (KeyCode.Q)) {
			SpawnPlatform ();
			platformsNumber = platformsNumber + 1;
		}
	}

	private void SpawnPlatform () {
		Vector2 horOffset = new Vector2 (0, 2);
		Vector2 verOffset = new Vector2 (2, 0);
		Instantiate (platformPrefab, new Vector2 (0, 0), Quaternion.identity);
		platformsNumber = platformsNumber + 1;
	}

}
