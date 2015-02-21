using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BribeCountdown : MonoBehaviour {

	private static BribeCountdown instance;

	public GameObject KarmaCount, TimeCount, ProgressBar;

	private float timeRemaining;
	private float startingTime;
	private int karmaRemaining;
	private int startingKarma;

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

		timeRemaining -= Time.deltaTime;
		if (timeRemaining < 0) {
			endBribe ();
		}
		updateTime (timeRemaining);
		updateKarma (startingKarma);

		RectTransform prog = ProgressBar.GetComponent<RectTransform> ();
		prog.localScale = new Vector3 (timeRemaining / startingTime, 1, 1);
	}

	public static void initBribeCountdown(int bribe) {
		instance.enabled = true;
		instance.calculateValues (bribe);
	}

	public void calculateValues(int bribe) {
		startingKarma = (int) ((float) bribe * 1.5) + 1;
		timeRemaining = bribe * 3;
		startingTime = timeRemaining;
	}

	public void updateTime(float seconds) {
		Text timeText = TimeCount.GetComponent<Text> ();
		int timeMinutes = (int) seconds / 60;
		int timeSeconds = (int) seconds % 60 + 1;

		string padding = "";
		if (timeSeconds < 10) {
			padding = "0";
		}

		timeText.text = timeMinutes.ToString() + ":" + padding + timeSeconds.ToString();
	}

	public void updateKarma(int start) {
		Text karma = KarmaCount.GetComponent<Text> ();
		karma.text = karmaRemaining.ToString();

		karmaRemaining = (int) ((float) startingKarma * (timeRemaining / startingTime));
	}

	private void endBribe() {
		Runner.isEnabled (true);
		Runner.incrementKarmaBy (karmaRemaining);
		GUIManager.hideBribeCountdown ();
	}
}
