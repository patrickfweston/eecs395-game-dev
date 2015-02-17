using UnityEngine;
using System.Collections;

public class GUIManager : MonoBehaviour {
	
	private static GUIManager instance;
	public GUIText foodCount; 

	// Use this for initialization
	void Start () {
		instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public static void updatePizzaCount(int count) {
		instance.foodCount.text = count.ToString();
	}
}
