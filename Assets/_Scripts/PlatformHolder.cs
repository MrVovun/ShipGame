using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlatformHolder : MonoBehaviour {

	public int platformsNumber;
	public Canvas gameCanvas;

	[SerializeField]
	private GameObject platformLord;

	private Vector2 yOffset = new Vector2 (0, -2);
	private Vector2 xOffset = new Vector2 (-2, 0);

	void Start () {
		for (int i = 0; i < platformsNumber; i++) {
			Platform thisPlatform = platformLord.GetComponent<SpawnPlatforms> ().SpawnPlatform ();
			thisPlatform.GetComponentInChildren<Platform> ().platformNumber = i;
			if (i % 2 == 0) {
				//spawn platform with offset on y
			} else {
				//spawn platform with offset on x
			}
			gameCanvas.GetComponent<SpawnButtons> ().Spawn ().GetComponentInChildren<PlatformButton> ().myPlatform = thisPlatform;

		}
	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.Q)) {
			Platform thisPlatform = platformLord.GetComponent<SpawnPlatforms> ().SpawnPlatform ();
			thisPlatform.GetComponentInChildren<Platform> ().platformNumber = platformsNumber;
			if (platformsNumber % 2 == 0) {
				//spawn platform with offset on y
			} else {
				//spawn platform with offset on x
			}
			gameCanvas.GetComponent<SpawnButtons> ().Spawn ().GetComponentInChildren<PlatformButton> ().myPlatform = thisPlatform;
			platformsNumber = platformsNumber + 1;
		}
	}

}
