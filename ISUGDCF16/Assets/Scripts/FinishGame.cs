using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FinishGame : MonoBehaviour {

    public GameObject timerText;
    public Text winText;

    //if the player enters the collider, trigger the finish game event
    void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Player")) {
           timerText.SendMessage("finished");
            winText.color = Color.green;
            winText.text = "GOAL!";
        }
    }
}
