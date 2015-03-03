using UnityEngine;
using System.Collections;

public class LineOfSightBossBehavior : IBossBehavior {

	// where boss will track to
	public GameObject target;

	public float attackVelocity;

	public LineOfSightBossBehavior(GameObject targetObj) {
		target = targetObj;
		attackVelocity = 0.05f;
	}

	// delegate function for boss to call to handle collision
	void IBossBehavior.collideWithPlayer() {
//		Debug.Log("Collide with player");
	}
	
	// called during fixed update in boss
	void IBossBehavior.Update(Boss b) {
		// calculate unit vector direction
		Vector3 attackDirection = target.transform.position - b.transform.position;
		attackDirection.Normalize ();

		b.transform.Translate (attackVelocity * attackDirection);

	}
}
