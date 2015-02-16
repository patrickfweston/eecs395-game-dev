using UnityEngine;
using System.Collections;

public class BribeInterface : MonoBehaviour {

	public GUIText bribeText, bribeHelp, bribeAmount, bribeSubtitle, bribeInstructions;

	// Use this for initialization
	void Start () {
		bribeText.enabled = false;
		bribeHelp.enabled = false;
		bribeAmount.enabled = false;
		bribeSubtitle.enabled = false;
		bribeInstructions.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
