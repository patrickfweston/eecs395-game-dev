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

		// -1 -0.5 1
		
		// 9 -0.5 17
		GameObject tempplayer = GameObject.Find ("Runner");

		GameObject tempboss = GameObject.Find ("boss0");
		AStarAI astar = tempboss.GetComponent<AStarAI> ();

		Vector3 pos1 = new Vector3 (-1f, -0.5f, 1f);
		Vector3 pos2 = new Vector3 (9f, -0.5f, 17f);

		float distpos1 = Vector3.Distance (pos1, tempplayer.transform.localPosition);
		float distpos2 = Vector3.Distance (pos2, tempplayer.transform.localPosition);

		if (distpos1 > distpos2) {
			astar.updateTargetPosition (pos1);
		}
		else {
			astar.updateTargetPosition(pos2);
		}

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
