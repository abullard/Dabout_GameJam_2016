using UnityEngine;
using System.Collections;

public class CannonBall : MonoBehaviour {
    public GameObject Explosion;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ContactPoint contact = collision.contacts[0];
            Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
            Vector3 pos = contact.point;
            Instantiate(Explosion, pos, rot);

			Player.player.endurance = 0.1f;

			Vector3 explosionPos = transform.position;
			Collider[] colliders = Physics.OverlapSphere(explosionPos, 2f);
			foreach (Collider hit in colliders) {
				Rigidbody rb = hit.GetComponent<Rigidbody>();
				if (rb != null){
					rb.AddExplosionForce(1000f, explosionPos, 2f, 1f);
				}
			}
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("destroyAmmo"))
        {
            Destroy(gameObject);
        }
       
    }
}
