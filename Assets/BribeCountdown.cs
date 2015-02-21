using UnityEngine;
using System.Collections;

public class BribeCountdown : MonoBehaviour {

	private static BribeCountdown instance;

	// Use this for initialization
	void Start () {
		instance = this;
	}

	void Awake () {
		instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp ("escape")) {
			endBribe();
		}
	}

	public static void initBribeCountdown() {
		instance.enabled = true;
	}

	private void endBribe() {
		Runner.isEnabled (true);
		GUIManager.hideBribeCountdown ();
	}
}
