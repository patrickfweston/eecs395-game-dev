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
		if (Input.GetKeyUp ("return")) {
			endBribe();
		}

		timeRemaining -= Time.deltaTime;
		if (timeRemaining < 0) {
			endBribe ();
		}

		Text timeText = TimeCount.GetComponent<Text> ();
		timeText.text = updateTime(timeRemaining);

		Text karma = KarmaCount.GetComponent<Text> ();
		karma.text = updateKarma (startingKarma);

		RectTransform prog = ProgressBar.GetComponent<RectTransform> ();
		prog.localScale = new Vector3 (timeRemaining / startingTime, 1, 1);
	}

	public static void initBribeCountdown(int bribe) {
		instance.enabled = true;
		instance.calculateValues (bribe);
	}

	public void calculateValues(int bribe) {
		startingKarma = getKarmaAmount(bribe);
		timeRemaining = getTime (bribe);
		startingTime = timeRemaining;
	}

	public static int getKarmaAmount(int bribe) {
		return (int)Mathf.Round((float)bribe * 1.5f);
	}

	public static int getTime(int bribe) {
		return bribe * 3;
	}
	
	public static string updateTime(float seconds) {
		int timeMinutes = (int) seconds / 60;
		int timeSeconds = (int) seconds % 60;

		string padding = "";
		if (timeSeconds < 10) {
			padding = "0";
		}

		return timeMinutes.ToString() + ":" + padding + timeSeconds.ToString();
	}

	public string updateKarma(int start) {
		karmaRemaining = (int) Mathf.Round((float) start * (timeRemaining / startingTime));
		return karmaRemaining.ToString ();
	}

	private void endBribe() {
		Runner.isEnabled (true);
		Runner.incrementKarmaBy (karmaRemaining);
		GUIManager.hideBribeCountdown ();
	}
}
