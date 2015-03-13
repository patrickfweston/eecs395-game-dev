using UnityEngine;
using System.Collections;

public class EndWin : MonoBehaviour {

	public static EndWin instance;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Awake() {
		instance = this;
	}

	public static void initEndWin() {
		instance.enabled = true;
		instance.GetComponent<Canvas> ().enabled = true;
		instance.GetComponent<Canvas> ().enabled = false;
		instance.GetComponent<Canvas> ().enabled = true;
		Runner.isEnabled (false);
		Boss.isEnabled (false);
	}
}
