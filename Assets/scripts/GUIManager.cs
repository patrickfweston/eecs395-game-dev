using UnityEngine;
using System.Collections;

public class GUIManager : MonoBehaviour {
	
	private static GUIManager instance;
	public Canvas bS, bC;
	public GUIText foodCount; 

	private static Canvas bribeScreen, bribeCountdown;

	// Use this for initialization
	void Start () {
		instance = this;

		bribeScreen.enabled = true;
		bribeCountdown.enabled = false;
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

	public static void showBribeScreen() {
		BribeScreen.initBribeScreen ();
		bribeScreen.enabled = true;
		Debug.Log("GUIManager");
	}
}
