using UnityEngine;
using System.Collections;

public class Pizza : MonoBehaviour {

	void OnCollisionEnter(Collision col){
		Debug.Log ("got pizza");
		if (col.gameObject.name == "Runner") {
			Destroy(gameObject);
			Runner.incrementPizzaBy(1);
		}
	}

}
