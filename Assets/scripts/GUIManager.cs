using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GUIManager : MonoBehaviour {
	
	private static GUIManager instance;
	public Canvas bS, bC;
	public GUIText foodCount, karmaCount; 

	private static Canvas bribeScreen, bribeCountdown;

	// Use this for initialization
	void Start () {
		instance = this;

		bribeScreen.gameObject.SetActive (true);
		showBribeScreen ();
		bribeCountdown.gameObject.SetActive (false);
		updatePizzaCount (Runner.getFoodCount());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Called when the GameObject is awoken
	void Awake () {
		bribeScreen = bS;
		bribeCountdown = bC;
	}
	
	public static void updatePizzaCount(int count) {
		instance.foodCount.text = count.ToString();
	}

	public static void updateKarmaCount(int karma) {
		instance.karmaCount.text = karma.ToString ();
	}

	public static void showBribeScreen() {
		BribeScreen.initBribeScreen ();
		bribeScreen.enabled = true;
		bribeScreen.gameObject.SetActive (true);
	}

	public static void hideBribeScreen() {
		bribeScreen.gameObject.SetActive(false);
	}

	public static void showBribeCountdown(int bribe) {
		BribeCountdown.initBribeCountdown(bribe);
		bribeCountdown.enabled = true;
		bribeCountdown.gameObject.SetActive(true);
	}

	public static void hideBribeCountdown() {
		bribeCountdown.gameObject.SetActive (false);
	}
}
