using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlatformHolder : MonoBehaviour {

	public int platformsNumber;
	public Canvas gameCanvas;

	[SerializeField]
	private GameObject platformLord;

	void Start () {
		for (int i = 0; i < platformsNumber; i++) {
			Platform thisPlatform = platformLord.GetComponent<SpawnPlatforms> ().SpawnPlatform ();
			thisPlatform.GetComponentInChildren<Platform> ().platformNumber = i;
			gameCanvas.GetComponent<SpawnButtons> ().Spawn ().GetComponentInChildren<PlatformButton> ().myPlatform = thisPlatform;

		}
	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.Q)) {
			Platform thisPlatform = platformLord.GetComponent<SpawnPlatforms> ().SpawnPlatform ();
			thisPlatform.GetComponentInChildren<Platform> ().platformNumber = platformsNumber;
			gameCanvas.GetComponent<SpawnButtons> ().Spawn ().GetComponentInChildren<PlatformButton> ().myPlatform = thisPlatform;
			platformsNumber = platformsNumber + 1;
		}
	}

}
