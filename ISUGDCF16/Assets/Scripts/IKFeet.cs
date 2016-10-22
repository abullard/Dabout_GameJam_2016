using UnityEngine;
using System.Collections;

public class IKFeet : MonoBehaviour {

	public Animator animator;
	public Transform targetL;
	public Transform targetR;

	void Start(){
		targetL.parent = null;
		targetR.parent = null;
	}
	
	// Update is called once per frame
	void OnAnimatorIK(){
		//if(targetL.position > 
		animator.SetIKPositionWeight(AvatarIKGoal.LeftFoot, 1f);
		animator.SetIKPositionWeight(AvatarIKGoal.RightFoot, 1f);
		animator.SetIKPosition(AvatarIKGoal.LeftFoot, targetL.position);
		animator.SetIKPosition(AvatarIKGoal.LeftFoot, targetR.position);
		animator.SetIKRotationWeight(AvatarIKGoal.LeftFoot, 1f);
		animator.SetIKRotationWeight(AvatarIKGoal.RightFoot, 1f);
		animator.SetIKRotation(AvatarIKGoal.LeftFoot, targetL.rotation);
		animator.SetIKRotation(AvatarIKGoal.LeftFoot, targetR.rotation);
	}
}
