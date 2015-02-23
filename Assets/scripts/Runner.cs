using UnityEngine;

public class Runner : MonoBehaviour {

	private static int numFood;
	private static int karma;
	private static Runner instance;
	private static bool enabled;

	void Start() {
		instance = this;
		numFood = 10;
		enabled = true;
	}

	void Update () {
		if (enabled) {
			move_character ();
		}
	}

	void move_character() {
		if (Input.GetKey ("right")) {
			move_right ();
		}
		if (Input.GetKey ("left")) {
			move_left ();	
		}
		if (Input.GetKey ("up")) {
			move_forward();	
		}
		if (Input.GetKey ("down")) {
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

	public static void incrementPizzaBy(int count) {
		numFood += count;
		GUIManager.updatePizzaCount(numFood);
	}

	public static void decrementPizzaBy(int count) {
		numFood -= count;
		GUIManager.updatePizzaCount(numFood);
	}

	public static void incrementKarmaBy(int count) {
		karma += count;
		GUIManager.updateKarmaCount(karma);
	}
	
	public static void decrementKarmaBy(int count) {
		karma -= count;
		GUIManager.updateKarmaCount(karma);
	}

	public static int getFoodCount() {
		return numFood;
	}

	public static void isEnabled(bool x) {
		enabled = x;
//		Debug.Log ("disabled");
	}
}