using UnityEngine;
using System.Collections;

public class WaterRespawn : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Player.player.respawn();
        }
    }
}
