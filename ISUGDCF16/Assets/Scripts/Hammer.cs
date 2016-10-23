using UnityEngine;
using System.Collections;

public class Hammer : MonoBehaviour {

	public HingeJoint hinge;
	public JointMotor motor;

	// Use this for initialization
	void Start () {
		hinge = GetComponent <HingeJoint> ();
		motor = hinge.motor;

		motor.force = 100;
		motor.targetVelocity = 100;
		motor.freeSpin = false;
		hinge.motor = motor;
		hinge.useMotor = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	
	}
}
