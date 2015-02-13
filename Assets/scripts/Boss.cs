using UnityEngine;
using System.Collections;

public class Boss : MonoBehaviour {

	private float smooth = 5;
	Color angry = Color.red;
	Color calm = Color.yellow;
//	gameObject.Collider.Material = null;

	void Angry(){
		Color oldColor = gameObject.renderer.material.color;
		gameObject.renderer.material.color = Color.Lerp(oldColor, angry, Time.deltaTime * smooth);
	}
	 
	void Calm(){
		gameObject.renderer.material.color = calm;
	}

	void OnCollisionStay(Collision col){
		if (col.gameObject.name == "Runner") {
			Angry();
		}
	}

	void OnCollisionExit(Collision col){
//		Debug.Log ("calm");
		if (col.gameObject.name == "Runner") {
			Calm();
		}
	}

}
