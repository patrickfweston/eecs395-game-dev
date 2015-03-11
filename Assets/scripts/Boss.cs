using UnityEngine;
using System.Collections;

public class Boss : MonoBehaviour {

	public Light l;
	private float smooth = 5;
	Color angry = Color.red;
	Color calm = Color.yellow;
	private bool wait = false;
	private int sec = 300;
	GameObject player;

	public static bool enabled;

	IBossBehavior behavior; 

	void Angry(){
		Color oldColor = gameObject.renderer.material.color;
		gameObject.renderer.material.color = Color.Lerp(oldColor, angry, Time.deltaTime * smooth);
		l.color = Color.Lerp(l.color, Color.red, Time.deltaTime);
		Manager.changelight = true;
	}
	 
	void Calm(){
		gameObject.renderer.material.color = calm;
		l.color = Color.white;
		Manager.changelight = false;
	}

	void Start() {
		player = GameObject.Find("Runner");
		l = player.GetComponentsInChildren<Light>()[0];
		behavior = new LineOfSightBossBehavior (player);

	}

	IEnumerator Wait(){
		yield return new WaitForSeconds (10.0f);
	}

	void Update() {
		if (enabled) {
			if (!Runner.get_status ()) {
				Angry ();
				Vector3 new_pos = player.transform.localPosition + new Vector3 (5, 0, 5);
				gameObject.transform.localPosition = Vector3.Lerp (gameObject.transform.localPosition, new_pos, Time.deltaTime);
			} else {
				Calm ();
				if (wait) {
					if (sec > 0) {
						sec--;
					} else { 
						wait = false;
						sec = 300;
					}
				} else {
					behavior.Update (this);
				}
			}
		}
	}

	void OnCollisionStay(Collision col){
		if (col.gameObject.name == "Runner") {
			Angry();
			behavior.collideWithPlayer();
			GUIManager.showBribeScreen();
		}
	}

	void OnCollisionExit(Collision col){
		if (col.gameObject.name == "Runner") {	
//			Calm();
			wait = true;
		}

	}

	public static void isEnabled(bool x) {
		enabled = x;
	}

}
