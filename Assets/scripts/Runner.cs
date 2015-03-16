using UnityEngine;
using System.Collections;

public class Runner : MonoBehaviour {

	private static int numFood;
	private static int karma;
	private static Runner instance;
	private static bool enabled;

	public AudioClip Eating_sound;
	public GameObject manager;
	public Manager script_manager;
	
	public AudioSource s;

	private static int lastDirection = 0;
	// 0 - up, 1 - right, 2 - down, 3 - left

	public GameObject justin;
	private Animator anim;



	void Start() {

		InstructionsScreen.showInstructions ();

		instance = this;
		numFood = 10;
		anim = instance.justin.GetComponent<Animator> ();
		script_manager = manager.GetComponent<Manager>();
	}

	void Update () {



		if (enabled) {
			move_character ();
		} else {
			anim.speed = 0f;
		}
	}

	void move_character() {
		if (!Input.GetKey ("up") && !Input.GetKey ("right") && !Input.GetKey ("left") && !Input.GetKey ("down")) {
			anim.speed = 0f;
		} else {
			anim.speed = 1.1f;
		}

		if (Input.GetKey ("right")) {
			if (Input.GetKey ("up")||Input.GetKey ("down")){
				move_right (Mathf.Sqrt(0.5f));
			}
			else move_right (1f);
			lastDirection = 1;
		}
		if (Input.GetKey ("left")) {
			if (Input.GetKey ("up")||Input.GetKey ("down")){
				move_left (Mathf.Sqrt(0.5f));
			}
			else move_left (1f);	
			lastDirection = 3;
		}
		if (Input.GetKey ("up")) {
			if (Input.GetKey ("left")||Input.GetKey ("right")){
				move_forward (Mathf.Sqrt(0.5f));
			}
			else move_forward(1f);	
			lastDirection = 0;
		}
		if (Input.GetKey ("down")) {
			if (Input.GetKey ("left")||Input.GetKey ("right")){
				move_backward (Mathf.Sqrt(0.5f));
			}
			else move_backward(1f);
			lastDirection = 2;
		}
	}

	void move_right (float c) {
		transform.Translate(5f * Time.deltaTime * c, 0f, 0f);

		if (lastDirection != 1) {
			justin.transform.localEulerAngles = new Vector3(0f, 90f, 0f);
		}
	}

	void move_left (float c) {
		transform.Translate(-5f * Time.deltaTime * c, 0f, 0f);
		if (lastDirection != 3) {
			justin.transform.localEulerAngles = new Vector3(0f, -90f, 0f);
		}
	}

	void move_forward (float c) {
		transform.Translate(0f, 0f,5f * Time.deltaTime * c);
		if (lastDirection != 0) {
			justin.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
		}
	}

	void move_backward(float c) {
		transform.Translate(0f, 0f, -5f * Time.deltaTime * c);
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

		Debug.Log (karma.ToString ());
		if (karma > GUIManager.getEndKarma()) {
			GUIManager.endGameWin();
		}
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

	void OnCollisionEnter(Collision col){
		Debug.Log (col.gameObject.name);
		if (col.gameObject.name == "pizza") {
//			Debug.Log ("got pizza");

			Runner.incrementPizzaBy(1);
			script_manager.NumOfPizza--;
//			Debug.Log(script_manager.NumOfPizza);
			
			//			source.pitch = Random.Range (lowPitchRange,highPitchRange);
			//			float hitVol = col.relativeVelocity.magnitude * velToVol;
			
			s.clip = Eating_sound;
			s.Play();
			
			//			Debug.Log("played sound");
//			renderer.enabled = false;
//			col.gameObject.GetComponent<BoxCollider>().enabled = false;
//			yield return new WaitForSeconds(s.clip.length);
			//			SelfDe
			Destroy(col.gameObject);
		}
	}

}