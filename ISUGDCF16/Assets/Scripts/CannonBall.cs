using UnityEngine;
using System.Collections;

public class CannonBall : MonoBehaviour {
	public GameObject prefab;
    public Transform target;
    public float thrust = 10f;
    // Update is called once per frame
    IEnumerator Start()
    {

        yield return new WaitForSeconds(Random.Range(0f,2f));
        
        while (true)
        {
            if (target)
                transform.LookAt(target);
            
            GameObject projectile = (GameObject)Instantiate(prefab, transform.position, transform.rotation);
            projectile.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * thrust, ForceMode.VelocityChange);
            yield return new WaitForSeconds(1.5f);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            target = other.gameObject.transform;
        }
    }
}
