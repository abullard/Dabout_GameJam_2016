using UnityEngine;
using System.Collections;

public class ProjectileDestroyer : MonoBehaviour {
	
	// Update is called once per frame
	void OnTriggerEnter(Collider other) {
	
        if(other.gameObject.CompareTag("projectile")) {
            Destroy(other);
        }

	}
}
