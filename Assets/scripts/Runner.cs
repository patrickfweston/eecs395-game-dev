using UnityEngine;

public class Runner : MonoBehaviour {

	void Update () {
		if (Input.GetKey("right")) {
			move_right();

		}
		if (Input.GetKey("left")) {
			move_left();
			
		}
		if (Input.GetKey("up")) {
			move_forward();
			
		}
		if (Input.GetKey("down")) {
			move_back();
			
		}
	}

	void move_right () {
		transform.Translate(5f * Time.deltaTime, 0f, 0f);
	}

	void move_left () {
		transform.Translate(-5f * Time.deltaTime, 0f, 0f);
	}
	void move_forward () {
		transform.Translate(0f, 0f,5f * Time.deltaTime);
	}
	void move_back () {
		transform.Translate( 0f, 0f,-5f * Time.deltaTime);
	}
}