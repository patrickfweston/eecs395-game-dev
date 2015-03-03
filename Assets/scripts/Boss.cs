using UnityEngine;
using System.Collections;

public class Boss : MonoBehaviour {

	public Light l;
	private float smooth = 5;
	Color angry = Color.red;
	Color calm = Color.yellow;
	private bool wait = false;
	private int sec = 300;

	IBossBehavior behavior; 

	void Angry(){
		Color oldColor = gameObject.renderer.material.color;
		gameObject.renderer.material.color = Color.Lerp(oldColor, angry, Time.deltaTime * smooth);
	}
	 
	void Calm(){
		gameObject.renderer.material.color = calm;
	}

	void Start() {
		behavior = new LineOfSightBossBehavior (GameObject.Find("Runner"));

	}

	IEnumerator Wait(){
		yield return new WaitForSeconds (10.0f);
	}

	void Update() {
		if(wait){
			if(sec >0){
				sec--;
			}
			else { 
				wait = false;
				sec = 9000;
				Debug.Log("!");
			}
		}

		else {
			behavior.Update(this);
		}
	}

	void OnCollisionStay(Collision col){
		if (col.gameObject.name == "Runner") {
			Angry();
			behavior.collideWithPlayer();
//			GUIManager.showBribeScreen();


			Light mylight = col.gameObject.GetComponentsInChildren<Light>()[0];
			mylight.color = Color.Lerp(mylight.color, Color.red, Time.deltaTime);
//			GameObject.Find("")/
			Manager.changelight = true;
		}
	}

	void OnCollisionExit(Collision col){
//		Debug.Log ("calm");
		if (col.gameObject.name == "Runner") {	
			Calm();
			Light mylight = col.gameObject.GetComponentsInChildren<Light>()[0];
			mylight.color = Color.white;
			Manager.changelight = false;
			wait = true;
		}

	}

}
