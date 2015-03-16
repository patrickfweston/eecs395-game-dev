using UnityEngine;

public class Desk : CellEdge {

	void OnCollisionStay(Collision col){
		if (col.gameObject.name == "Runner") {
//			Debug.Log("Enter desk!");
			GUIManager.showBribeScreen ();

			// -1 -0.5 1
			GameObject tempboss = GameObject.Find ("boss0");
			AStarAI astar = tempboss.GetComponent<AStarAI> ();
			astar.updateTargetPosition(new Vector3(-1f, -0.5f, 1f));
		}
	}
	
	void OnCollisionExit(Collision col){
		if (col.gameObject.name == "Runner") {
//			Debug.Log("Leave desk!");
		}
	}
}