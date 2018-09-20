using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalAttack : MonoBehaviour {

	private bool active = false;

	private float timer = 0.0f;
	private float activeTime = 3.0f;
	public float hitstun = 30.0f * (1/60.0f);

	public void DoAttack(float activeTime, float hitstun){
		this.activeTime = activeTime;
		this.hitstun = hitstun;
		active = true;
	}

	void Update () {
		
		if(active){
			timer += Time.deltaTime;
			if (timer > activeTime) {
				Destroy(gameObject);
			}
		}

	}
}
