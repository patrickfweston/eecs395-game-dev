using UnityEngine;

public class Runner : MonoBehaviour {

	private static int numFood;
	private static int karma;
	private static Runner instance;
	private static bool enabled;

	private static int lastDirection = 0;
	// 0 - up, 1 - right, 2 - down, 3 - left

	public GameObject justin;
	private Animator anim;

	void Start() {



		instance = this;
		numFood = 10;
		enabled = true;
		anim = instance.justin.GetComponent<Animator> ();
	}

	void Update () {



		if (enabled) {
			move_character ();
		}
	}

	void move_character() {
		if (!Input.GetKey ("up") && !Input.GetKey ("right") && !Input.GetKey ("left") && !Input.GetKey ("down")) {
			anim.speed = 0f;
		} else {
			anim.speed = 1.1f;
		}

		if (Input.GetKey ("right")) {
			move_right ();
			lastDirection = 1;
		}
		if (Input.GetKey ("left")) {
			move_left ();	
			lastDirection = 3;
		}
		if (Input.GetKey ("up")) {
			move_forward();	
			lastDirection = 0;
		}
		if (Input.GetKey ("down")) {
			move_backward();
			lastDirection = 2;
		}
	}

	void move_right () {
		transform.Translate(5f * Time.deltaTime, 0f, 0f);

		if (lastDirection != 1) {
			justin.transform.localEulerAngles = new Vector3(0f, 90f, 0f);
		}
	}

	void move_left () {
		transform.Translate(-5f * Time.deltaTime, 0f, 0f);
		if (lastDirection != 3) {
			justin.transform.localEulerAngles = new Vector3(0f, -90f, 0f);
		}
	}

	void move_forward () {
		transform.Translate(0f, 0f,5f * Time.deltaTime);
		if (lastDirection != 0) {
			justin.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
		}
	}

	void move_backward() {
		transform.Translate(0f, 0f, -5f * Time.deltaTime);
		if (lastDirection != 2) {
			justin.transform.localEulerAngles = new Vector3(0f, 180f, 0f);
		}
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

	public static bool get_status(){
		return enabled;
	}
}