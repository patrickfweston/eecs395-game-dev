using UnityEngine;

public class Runner : MonoBehaviour {

	void Update () {
		if (Input.GetKey("right")) {
			move_right();

		}
		if (Input.GetKey("left")) {
			move_left();
			
		}
	}

	void move_right () {
		transform.Translate(5f * Time.deltaTime, 0f, 0f);
	}

	void move_left () {
		transform.Translate(-5f * Time.deltaTime, 0f, 0f);
	}
}