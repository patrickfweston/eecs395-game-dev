using UnityEngine;
using System.Collections;

public class EatPizza : MonoBehaviour {

	void OnCollisionEnter(Collision col){
//		Debug.Log ("got pizza");
		if (col.gameObject.name == "Pizza") {
			Destroy(col.gameObject);
		}
	}
}
