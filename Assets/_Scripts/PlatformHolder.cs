using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformHolder : MonoBehaviour {

	public int platformsNumber = 6;

	[SerializeField]
	private Platform platformPrefab;

	private void Awake () {
		Vector2 horOffset = new Vector2 (0, 2);
		Vector2 verOffset = new Vector2 (2, 0);
		for (int i = 0; i < 6; i++) {
			if (i % 2 != 0) {
				Instantiate (platformPrefab, new Vector2 (0, 0) + verOffset, Quaternion.identity);
				verOffset = verOffset + new Vector2 (2, 0);
			} else if (i % 2 == 0) {
				Instantiate (platformPrefab, new Vector2 (0, 0) + horOffset, Quaternion.identity);
				horOffset = horOffset + new Vector2 (0, 2);
			}
		}
	}

}
