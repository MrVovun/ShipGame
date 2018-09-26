using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlatforms : MonoBehaviour {

	public Platform platformPrefab;

	public Platform SpawnPlatform () {
		Platform myPlatform = Instantiate (platformPrefab, new Vector2 (0, 0), Quaternion.identity);
		return myPlatform;
	}
}
