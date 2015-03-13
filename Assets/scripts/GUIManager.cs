using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GUIManager : MonoBehaviour {
	
	private static GUIManager instance;
	public Canvas bS, bC, eW, eL;
	public GUIText foodCount, karmaCount, karmaTotal; 
	public int karmaEndGameTotal;

	private static Canvas bribeScreen, bribeCountdown, endWin, endLoss;

	// Use this for initialization
	void Start () {
		instance = this;

		karmaTotal.text = karmaEndGameTotal.ToString ();

		bribeScreen.gameObject.SetActive (false);
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
		endWin = eW;
		endLoss = eL;
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


	public static void endGameWin() {
		endWin.enabled = true;
		endWin.gameObject.SetActive(true);
		EndWin.initEndWin ();
	}

	public static void endGameLoss() {
		endLoss.enabled = true;
		endLoss.gameObject.SetActive(true);
		EndLoss.initEndLoss ();
	}


	public static int getEndKarma() {
		return instance.karmaEndGameTotal;
	}
}
