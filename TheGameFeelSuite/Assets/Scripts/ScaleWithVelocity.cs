using UnityEngine;

public class ScaleWithVelocity : MonoBehaviour {

	[SerializeField] Rigidbody2D rb;
	[SerializeField] CharacterController2D cc;

	//The speeds to reach before maximum scaling is acheived
	[SerializeField] private float maxYSpeed = 0.0f;
	[SerializeField] private float maxXSpeed = 0.0f;

	void FixedUpdate() {

		//Going fast
		float fastScaleX = 1.0f;
		float fastScaleY = 1.0f;

		//Going slow
		float slowScaleX = 1.0f;
		float slowScaleY = 1.0f;

		//How lerped will the scale be
		float ySpeedRatio = Mathf.Abs(rb.velocity.y) / maxYSpeed;
		float xLerp = Mathf.Lerp(slowScaleX, fastScaleX, ySpeedRatio);
		float yLerp = Mathf.Lerp(slowScaleY, fastScaleY, ySpeedRatio);
		Debug.Log("ySpeedRatio: " + ySpeedRatio + ", xLerp: " + xLerp + ", yLerp: " + yLerp);

		transform.localScale = new Vector2(xLerp, yLerp);
	}

	public void SetMaxYSpeed(float speed) {
		maxYSpeed = speed;
	}

	public void SetMaxXSpeed(float speed) {
		maxXSpeed = speed;
	}
}
