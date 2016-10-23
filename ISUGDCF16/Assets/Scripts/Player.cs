using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour{

	public static Player player;

	public float endurance = 1f; // how fast he can get up and stay upright, lowered when he gets hurt
	public float recoveryRate = 1f; // how fast he recovers
    public bool recovering = false;


	public float runSpeed = 2f;
	public float jumpSpeed = 2f;
	public float uprightTension = 10f;
	public float turningStrength = 10f;
	
	public LayerMask ground; // if he is standing on this he may jump

	public Animator animator;


	Rigidbody rigidbody;
	Vector3 dir = Vector3.zero;

	public Transform spawnAt;
	public ParticleSystem spawnParticles;
	
	void Awake(){
		player = this;
		rigidbody = GetComponent<Rigidbody>();
	}

	public void respawn(){
		if(spawnAt){
			rigidbody.velocity = Vector3.zero;
			rigidbody.angularVelocity = Vector3.zero;
			transform.position = spawnAt.position;
			transform.rotation = spawnAt.rotation;
			spawnParticles.Play();
		}
	}

	public void setSpawn(Transform t){
		spawnAt = t;
	}
	
	void Update(){

		endurance = Mathf.Lerp(endurance, 1f, Time.deltaTime * recoveryRate);

		dir.x = Input.GetAxis("Horizontal");
		dir.z = Input.GetAxis("Vertical");
		dir = dir.normalized;
		
		dir = Camera.main.transform.TransformDirection(dir);
		dir.y = 0;
		dir = dir.normalized;
		
		Debug.DrawRay(transform.position, dir, Color.green);
		Debug.DrawRay(transform.position, transform.forward, Color.blue);

		if(Input.GetButtonDown("Jump")){
			if(Physics.CheckSphere(transform.TransformPoint(Vector3.down), 0.3f, ground)){
				rigidbody.AddForce(Vector3.up * jumpSpeed * endurance, ForceMode.VelocityChange);
			}
		}

		if(Input.GetKeyDown(KeyCode.T)){
			endurance = 0f;
			rigidbody.AddForce(Vector3.up * jumpSpeed, ForceMode.VelocityChange);
			rigidbody.AddRelativeTorque(Random.onUnitSphere * 10000f, ForceMode.VelocityChange);
		}
		if(Input.GetKeyDown(KeyCode.R)){
			respawn();
		}

		if(Input.GetKey(KeyCode.LeftShift))
			dab = Mathf.Lerp(dab, 1f, Time.deltaTime);
		else
			dab = Mathf.Lerp(dab, 0f, Time.deltaTime);
		animator.SetLayerWeight(1, dab);

		animator.speed = dir.sqrMagnitude;
	}

	float dab = 0f;

	void FixedUpdate(){

		rigidbody.AddForce(dir * runSpeed * endurance, ForceMode.Acceleration);

		if(dir.sqrMagnitude > 0.1f){
			//rigidbody(dir);
		}
		rigidbody.AddTension(Vector3.up * uprightTension * endurance, Vector3.up * endurance);

		//float dot = Vector3.Dot(dir, transform.forward);
		rigidbody.AddTension(dir * turningStrength * endurance, Vector3.forward * endurance);
		rigidbody.AddTension(transform.forward * turningStrength * endurance, Vector3.forward * endurance);
	}
}
