﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Ragdoll : MonoBehaviour{

	public GameObject pelvis;

	public float maxSpring = 100f;
	public float maxDamp = 50f;

	public Material invisible;

	public List<SpringJoint> springJoints;

	void Start(){
		GameObject ragPelvis = (GameObject)Instantiate(pelvis);
		ragPelvis.name = pelvis.name;
		//ragPelvis.transform.SetParent(transform);

		Camera.main.GetComponent<CameraController>().player = gameObject;

		SkinnedMeshRenderer skin = GetComponentInChildren<SkinnedMeshRenderer>();
		skin = ((GameObject)Instantiate(skin.gameObject)).GetComponent<SkinnedMeshRenderer>();
		//skin.transform.SetParent(transform);
		GetComponentInChildren<SkinnedMeshRenderer>().material = invisible;

		Transform[] armJoints = pelvis.GetComponentsInChildren<Transform>();
		Transform[] ragJoints = ragPelvis.GetComponentsInChildren<Transform>();

		for(int a = 0; a < armJoints.Length; a++){
			for(int r = 0; r < ragJoints.Length; r++){
				bool found = false;
				if(armJoints[a].name.Equals(ragJoints[r].name)){
					found = true;
					springJoints.Add(ragJoints[r].gameObject.AddComponent<SpringJoint>());
					springJoints[springJoints.Count-1].connectedBody = armJoints[a].gameObject.AddComponent<Rigidbody>();
					armJoints[a].GetComponent<Rigidbody>().isKinematic = true;
					springJoints[springJoints.Count-1].spring = maxSpring;
					springJoints[springJoints.Count-1].damper = maxDamp;
					springJoints[springJoints.Count-1].autoConfigureConnectedAnchor = false;
					springJoints[springJoints.Count-1].connectedAnchor = Vector3.zero;
					ragJoints[r].GetComponent<Rigidbody>().drag = 10f;
					ragJoints[r].gameObject.AddComponent<SphereCollider>().radius = 0.1f;
					//ragJoints[r].GetComponent<Rigidbody>().useGravity = false;
					ragJoints[r].GetComponent<Rigidbody>().interpolation = RigidbodyInterpolation.Interpolate;

					//Debug.Log("Linking " + armJoints[a].name + " and " + ragJoints[r].name);
				}
			}
		}

		skin.bones = ragJoints;

		//SpringJoint mainSpring = ragJoints[0].GetComponent<SpringJoint>();
		//mainSpring.spring = 100f;

		for(int i = 0; i < ragJoints.Length; i++){
			if(ragJoints[i].transform.parent && ragJoints[i].transform.parent.GetComponent<Rigidbody>()){
				ragJoints[i].gameObject.AddComponent<SpringJoint>().connectedBody = ragJoints[i].transform.parent.GetComponent<Rigidbody>();
				//ragJoints[i].transform.parent = null;
			}
		}
	}

	void FixedUpdate(){
		float e = Player.player.endurance;
		for(int i = 0; i < springJoints.Count; i++){
			springJoints[i].transform.rotation = springJoints[i].connectedBody.transform.rotation;
			springJoints[i].spring = maxSpring * e;// * i/springJoints.Count;
			Debug.DrawLine(springJoints[i].transform.position, springJoints[i].connectedBody.position, Color.magenta);
		}
	}
}
