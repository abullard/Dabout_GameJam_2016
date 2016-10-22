using UnityEngine;
using System.Collections;

public static class RigidbodyExtensions{

	// use tension to aim rigidbodies or stabalize them. Use a longer position for a longer offset, longer direction for more power
	public static void AddTension(this Rigidbody r, Vector3 direction, Vector3 localPosition){
		r.AddForceAtPosition(direction, r.transform.TransformVector(localPosition), ForceMode.Acceleration);
		r.AddForceAtPosition(-direction, r.transform.TransformVector(-localPosition), ForceMode.Acceleration);
	}

	public static void AddTension(this Rigidbody r, Vector3 direction, Vector3 localPosition, ForceMode forcemode){
		r.AddForceAtPosition(direction, r.transform.TransformVector(localPosition), forcemode);
		r.AddForceAtPosition(-direction, r.transform.TransformVector(-localPosition), forcemode);
	}
}
