using UnityEngine;

public class Desk : CellEdge {

	void OnCollisionStay(Collision col){
		if (col.gameObject.name == "Runner") {
//			Debug.Log("Enter desk!");
			GUIManager.showBribeScreen ();
		}
	}
	
	void OnCollisionExit(Collision col){
		if (col.gameObject.name == "Runner") {
//			Debug.Log("Leave desk!");
		}
	}
}