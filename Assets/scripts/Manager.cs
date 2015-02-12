using UnityEngine;
using System.Collections;

public class Manager : MonoBehaviour {
	public Boss BossPrefab;
	public Pizza PizzaPrefab;
	public int NumOfPizza;
	public int NumOfBoss;
	// Use this for initialization
	
	void Start () {
		generate_pizza ();
		generate_boss();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void generate_pizza(){
		for (int i = 0; i < NumOfPizza; i++) {
			Pizza newpizza = Instantiate(PizzaPrefab) as Pizza;
			newpizza.name = "pizza" + i;
			newpizza.transform.localPosition =
				new Vector3(Random.Range(-20,20), 0, Random.Range(-20,20));
		}
	}
	
	void generate_boss(){
		for (int i = 0; i < NumOfBoss; i++) {
			Boss newboss = Instantiate(BossPrefab) as Boss;
			newboss.name = "boss" + i;
			newboss.transform.localPosition =
				new Vector3(Random.Range(-20,20), 0, Random.Range(-20,20));
		}
	}
	
	
}

