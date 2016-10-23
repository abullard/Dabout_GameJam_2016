using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class CheckpointScript : MonoBehaviour {

    public Text checkpointText;
    public GameObject spawnPoint;

    //Set's player's spawn point, and displays 
    void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Player")) {
                Player.player.setSpawn(transform);
                checkpointText.text = "Checkpoint";
                Invoke("hideText", 2f);
        }
    }

    void hideText() {
        checkpointText.text = "";
    }
}
