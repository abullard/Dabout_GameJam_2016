using UnityEngine;
using System.Collections;

public class Cannon : MonoBehaviour
{
    public GameObject prefab;
    public float thrust;
    public Transform defaultTarget;

    // Update is called once per frame
    IEnumerator Start()
    {
        transform.parent.forward = transform.forward;
        yield return new WaitForSeconds(Random.Range(0f, 2f));
        while (true)
        {
            GameObject projectile = (GameObject)Instantiate(prefab, transform.position, transform.rotation);
            projectile.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * thrust, ForceMode.VelocityChange);
            yield return new WaitForSeconds(1.5f);
        }
    }
}