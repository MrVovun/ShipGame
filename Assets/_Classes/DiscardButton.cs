using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscardButton : MonoBehaviour {

    public void DiscardShip () {
        GameObject gameController = GameObject.FindGameObjectWithTag ("GameController");
        Ship firstShip = gameController.GetComponent<ShipGenerator> ().GetFirstShipInList ();
        gameController.GetComponent<ShipGenerator> ().ships.Remove (firstShip);
        Destroy (firstShip.gameObject);
    }

}
