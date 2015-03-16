using UnityEngine;

public class Desk : CellEdge {

	void OnCollisionStay(Collision col){
		if (col.gameObject.name == "Runner" && Runner.getFoodCount() > 0) {
//			Debug.Log("Enter desk!");
			GUIManager.showBribeScreen ();

			// -1 -0.5 1
			GameObject tempboss = GameObject.Find ("boss0");
			AStarAI astar = tempboss.GetComponent<AStarAI> ();
			astar.updateTargetPosition(tempboss.transform.localPosition);
		}
	}
	
	void OnCollisionExit(Collision col){
		if (col.gameObject.name == "Runner") {
//			Debug.Log("Leave desk!");
		}
	}
}