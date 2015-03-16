using UnityEngine;
using System.Collections;

public class InstructionsScreen : MonoBehaviour {

	private static InstructionsScreen instance;

	// Use this for initialization
	void Start () {
		instance = this;
	}

	void Awake() {
		instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey ("return")) {
			startGame();
		}
	}

	private void startGame() {
		instance.gameObject.SetActive (false);
		instance.enabled = false;
		Runner.isEnabled (true);
		Boss.isEnabled (true);
	}

	public static void showInstructions() {
		instance.gameObject.SetActive (true);
		instance.enabled = true;
		instance.GetComponent<Canvas> ().enabled = true;
		Runner.isEnabled (false);
		Boss.isEnabled (false);
//		Debug.Log ("here");
	}
}
