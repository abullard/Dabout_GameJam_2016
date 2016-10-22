using UnityEngine;
using System.Collections;

public class SpinningBlade : MonoBehaviour {
	
	public Rigidbody rb;
	public float torque;

	// Use this for initialization
	void Start () {
		rb = GetComponent <Rigidbody> ();
	}
	
	// Update is called once per frame
	void FixedUpdate(){
		rb.AddRelativeTorque (Vector3.up * torque);
		rb.AddForce (Vector3.forward * 1.0f, ForceMode.Acceleration);
	}

	void Update () {
		
	}
}
