using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

	public Platform myPlatform;
	public float timeLeft;

	private void Start () {
		myPlatform.myTimer = this;

	}

	private void Update () {
		this.GetComponent<Text> ().text = "" + Mathf.Round (timeLeft);
		if (timeLeft != 0) {
			timeLeft -= Time.deltaTime;
			if (timeLeft <= 0) {
				timeLeft = 0;

			}
		}
	}

	public void GetText () {
		timeLeft = myPlatform.timer;
	}
}
