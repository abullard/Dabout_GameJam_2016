using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class CheckpointScript : MonoBehaviour {

    public Text checkpointText;
    public GameObject checkpoint;
    private GameObject currentSpawn;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void OnTriggerEnter(Collider2D other) {
        if(other.gameObject.CompareTag("Player")) {
            Player.player.setSpawn(transform);
        }
    }
}
