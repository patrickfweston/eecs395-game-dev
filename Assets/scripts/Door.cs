using UnityEngine;

public class Door: CellEdge {

	void OnCollisionStay(Collision col){
		if (col.gameObject.name == "Runner") {
			Debug.Log("Enter room!");
		}
	}
	
	void OnCollisionExit(Collision col){
		//		Debug.Log ("calm");
		if (col.gameObject.name == "Runner") {
			Debug.Log("Leave room!");
		}
	}
}