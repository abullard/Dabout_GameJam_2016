using UnityEngine;
using System.Collections;

public class FinishGame : MonoBehaviour {

    public GameObject timerText;

    //if the player enters the collider, trigger the finish game event
    void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Player")) {
           timerText.SendMessage("finished");
        }
    }
}
