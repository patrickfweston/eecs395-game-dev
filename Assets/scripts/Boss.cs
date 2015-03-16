using UnityEngine;
using System.Collections;

using Pathfinding;

public class Boss : MonoBehaviour {

//	public Light l;
//	private float smooth = 5;
//	Color angry = Color.red;
//	Color calm = Color.yellow;
	private bool wait = false;
//	private int sec = 300;
	GameObject player;
//
	public static bool enabled;
	private AStarAI astar;
//
////	IBossBehavior behavior; 
//
//	void Angry(){
////		Color oldColor = gameObject.renderer.material.color;
////		gameObject.renderer.material.color = Color.Lerp(oldColor, angry, Time.deltaTime * smooth);
////		l.color = Color.Lerp(l.color, Color.red, Time.deltaTime);
////		Manager.changelight = true;
//	}
//	 
//	void Calm(){
////		gameObject.renderer.material.color = calm;
////		l.color = Color.white;
////		Manager.changelight = false;
//	}
//
//	void Start() {
////		player = GameObject.Find("Runner");
////		l = player.GetComponentsInChildren<Light>()[0];
////		behavior = new LineOfSightBossBehavior (player);
//
//	}

	void Start() {
		for (int i = 0; i < GetComponents(typeof(Component)).Length; i++) {
						Debug.Log (GetComponents (typeof(Component)) [i]);
				}

		astar = gameObject.GetComponent<AStarAI> ();
		player = GameObject.Find("Runner");
		StartCoroutine(updateRunnerPosition());
		Debug.Log (player);
	}

	IEnumerator Wait(){
		yield return new WaitForSeconds (10.0f);
	}

//	void Update() {
//		if (enabled) {
//			if (!Runner.get_status ()) {
//				Angry ();
//				Vector3 new_pos = player.transform.localPosition + new Vector3 (5, 0, 5);
//				gameObject.transform.localPosition = Vector3.Lerp (gameObject.transform.localPosition, new_pos, Time.deltaTime);
//			} else {
//				Calm ();
//				if (wait) {
//					if (sec > 0) {
//						sec--;
//					} else { 
//						wait = false;
//						sec = 300;
//					}
//				} else {
//					behavior.Update (this);
//				}
//			}
//		}
//	}
	
	void OnCollisionStay(Collision col){
		Debug.Log ("collision");
		if (col.gameObject.name == "Runner") {
//			Angry();
//			behavior.collideWithPlayer();
			GUIManager.endGameLoss();
		}
	}

	void OnCollisionExit(Collision col){
		if (col.gameObject.name == "Runner") {	
//			Calm();
			wait = true;
		}
	}

	IEnumerator updateRunnerPosition()
	{
		while(true)
		{
			if (Runner.get_status()) {
				astar.updateTargetPosition(player.transform.localPosition);
				Debug.Log (player.transform.localPosition);
			}
			yield return new WaitForSeconds(1);
		}
	}
	

	public static void isEnabled(bool x) {
		enabled = x;
	}



}
