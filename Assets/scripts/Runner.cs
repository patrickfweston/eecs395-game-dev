using UnityEngine;

public class Runner : MonoBehaviour {

	void Update () {
		if (Input.GetKey ("right")) {
			move_right ();

		} else if (Input.GetKey ("left")) {
			move_left ();
	
		} else if (Input.GetKey ("up")) {
			move_forward();

		} else if (Input.GetKey ("down")) {
			move_backward();

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

	void move_backward() {
		transform.Translate(0f, 0f, -5f * Time.deltaTime);
	}

//	void OnCollisionEnter(Collision col){
//		//		Debug.Log ("got pizza");
//		if (col.gameObject.name == "Pizza") {
//			Destroy(col.gameObject);
//		}
//	}
}