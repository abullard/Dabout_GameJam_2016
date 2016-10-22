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
            Destroy(gameObject);
        }
    }
}
