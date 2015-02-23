using UnityEngine;

public class Door: CellEdge {

	void OnCollisionStay(Collision col){
		if (col.gameObject.name == "Runner") {
			Debug.Log("Enter room!");
			GUIManager.showBribeScreen ();
		}
	}
	
	void OnCollisionExit(Collision col){
		if (col.gameObject.name == "Runner") {
			Debug.Log("Leave room!");
		}
	}
}