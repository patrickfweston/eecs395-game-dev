using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BribeScreen : MonoBehaviour {

	private static BribeScreen instance;
	public GameObject BribeAmount;

	private static int bribe;

	// Use this for initialization
	void Start () {
		instance = this;

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp ("return")) {
			submitBribe();
		}
		if (Input.GetKeyUp ("up")) {
			incrementBribeAmount(1);
		}
		if (Input.GetKeyUp ("down")) {
			decrementBribeAmount(1);
		}
	}

	void Awake () {
		instance = this;
	}

	public static void initBribeScreen() {
		instance.enabled = true;
		Runner.isEnabled (false);
		bribe = 0;
	}

	public void incrementBribeAmount(int x) {
		if (bribe + x <= Runner.getFoodCount()) {
			bribe = bribe + x;
			displayBribeAmount(bribe);
		}
	}

	public void decrementBribeAmount(int x) {
		if (bribe > 0) {
			bribe = bribe - 1;
			displayBribeAmount(bribe);
		}
	}

	public void displayBribeAmount(int x) {
		Text text = BribeAmount.GetComponent<Text> ();
		text.text = x.ToString ();
	}

	public void submitBribe() {
		Runner.decrementPizzaBy (bribe);
		GUIManager.hideBribeScreen ();
		GUIManager.showBribeCountdown (bribe);
	}
}
