using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour {

	CharacterController2D cc;
	Rigidbody2D rb;
	Animator anim;
	Attacking atk;

	// Use this for initialization
	void Start () {
		cc = GetComponent<CharacterController2D>();
		rb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
		atk = GetComponent<Attacking>();
	}
	
	// Update is called once per frame
	void Update () {
		
		if(rb.velocity.magnitude >= 0.5f && cc.onGround) {
			anim.SetTrigger("Running");
		}

		if (rb.velocity.magnitude < 0.5f && cc.onGround && !cc.GetGettingInput()) {
			anim.SetTrigger("Idle");
		}

		if (!cc.onGround) {
			anim.SetTrigger("Jumping");
		}

		if (atk.isAttacking) {
			cc.PauseThePlayer();
			anim.SetBool("IsAttacking", true);
		}

		if (!atk.isAttacking) {
			cc.UnpauseThePlayer();
			anim.SetBool("IsAttacking", false);
		}

		if (cc.GetInputDirection() == 1.0f){
			transform.localRotation = Quaternion.Euler(0, 0, 0);
		}

		if (cc.GetInputDirection() == -1.0f) {
			transform.localRotation = Quaternion.Euler(0, 180, 0);
		}
	}
}
