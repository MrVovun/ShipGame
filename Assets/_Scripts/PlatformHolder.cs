using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlatformHolder : MonoBehaviour {

	public int platformsNumber;
	public GameObject buttonHolder;

	[SerializeField]
	private GameObject platformLord;

	private Vector2 yoffset = new Vector2 (0, 0);
	private Vector2 xoffset = new Vector2 (1, 0);

	void Start () {
		for (int i = 0; i < platformsNumber; i++) {
			Platform thisPlatform = platformLord.GetComponent<SpawnPlatforms> ().SpawnPlatform ();
			thisPlatform.GetComponentInChildren<Platform> ().platformNumber = i;
			thisPlatform.transform.SetParent (platformLord.transform);
			if (i % 2 == 0) {
				thisPlatform.transform.localPosition = yoffset;
				yoffset = yoffset + new Vector2 (0, -1);
			} else {
				thisPlatform.transform.localPosition = xoffset;
				xoffset = xoffset + new Vector2 (0, -1);
			}
			buttonHolder.GetComponent<SpawnButtons> ().Spawn ().GetComponentInChildren<PlatformButton> ().myPlatform = thisPlatform;

		}
	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.Q)) {
			SpawnOneMorePlatform ();
		} {
			if (Input.GetKeyDown (KeyCode.E)) {
				buttonHolder.GetComponent<SpawnButtons> ().SpawnDiscardButton ();
			}
		}
	}

	void SpawnOneMorePlatform () {
		Platform thisPlatform = platformLord.GetComponent<SpawnPlatforms> ().SpawnPlatform ();
		thisPlatform.GetComponentInChildren<Platform> ().platformNumber = platformsNumber;
		thisPlatform.transform.SetParent (platformLord.transform);
		if (platformsNumber % 2 == 0) {
			thisPlatform.transform.localPosition = yoffset;
			yoffset = yoffset + new Vector2 (0, -1);
		} else {
			thisPlatform.transform.localPosition = xoffset;
			xoffset = xoffset + new Vector2 (0, -1);
		}
		buttonHolder.GetComponent<SpawnButtons> ().Spawn ().GetComponentInChildren<PlatformButton> ().myPlatform = thisPlatform;
		platformsNumber = platformsNumber + 1;
	}

}
