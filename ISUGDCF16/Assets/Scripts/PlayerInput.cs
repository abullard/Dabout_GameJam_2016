using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour{
	
	public float runSpeed = 2f;
	public float jumpSpeed = 2f;
	public float uprightTension = 10f;
	
	public LayerMask ground;
	
	Player player;
	Rigidbody rigidbody;
	Vector3 dir = Vector3.zero;
	
	void Awake(){
		player = GetComponent<Player>();
		rigidbody = GetComponent<Rigidbody>();
	}
	
	void Update(){
		dir.x = Input.GetAxis("Horizontal");
		dir.z = Input.GetAxis("Vertical");
		dir = dir.normalized;
		
		rigidbody.AddRelativeForce(dir * runSpeed, ForceMode.Acceleration);
		
		rigidbody.AddForceAtPosition(Vector3.up * uprightTension, transform.TransformVector(Vector3.up), ForceMode.Acceleration);
		rigidbody.AddForceAtPosition(Vector3.down * uprightTension, transform.TransformVector(Vector3.down), ForceMode.Acceleration);
		
		if(Input.GetButtonDown("Jump")){
			if(Physics.CheckSphere(transform.TransformPoint(Vector3.down), 0.2f, ground)){
				Debug.Log("Grounded");
				rigidbody.AddForce(Vector3.up * jumpSpeed, ForceMode.VelocityChange);
			}
		}
	}
}
