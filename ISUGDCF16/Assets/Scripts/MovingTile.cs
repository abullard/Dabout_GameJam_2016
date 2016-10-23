using UnityEngine;
using System.Collections;

public class MovingTile : MonoBehaviour {

    public float rightMax = 8.3f;
    public float leftMax = -8.5f;
    private bool dirRight = true;
    public float speed;

    // Use this for initialization
    void Start () {

        speed = Random.Range(1.5f, 4f);
        int ranDirection;

        ranDirection = Random.Range(0,2);
        if (ranDirection == 0)
            dirRight = true;
        else
            dirRight = false;
    }


    void Update()
    {
        if (dirRight)
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        else
            transform.Translate(Vector3.back * speed * Time.deltaTime);

        if (transform.position.z >= rightMax)
        {
            dirRight = false;
        }

        if (transform.position.z <= leftMax)
        {
            dirRight = true;
        }
    }
}
