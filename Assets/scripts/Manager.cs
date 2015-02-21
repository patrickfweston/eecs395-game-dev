using UnityEngine;
using System.Collections;

public class Manager : MonoBehaviour {

	//prefas
	public Map mapPrefab;
	public Boss BossPrefab;
	public Pizza PizzaPrefab;

	//member varaibles
	private Map mapInstance;
	private Pizza[] pizzas;
	private Boss[] bosses;
	public int NumOfPizza;
	public int NumOfBoss;

	// Use this for initialization
	void Start () {
		BeginGame();
		GUIManager.showBribeScreen ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void BeginGame () {
		mapInstance = Instantiate(mapPrefab) as Map;
		mapInstance.load_map_from_file("Assets/map_data");
		generate_pizza ();
		generate_boss();

	}

	void generate_pizza(){
		int xlimit = mapInstance.size.x * 1;
		int zlimit = mapInstance.size.z * 1;
		pizzas = new Pizza[NumOfPizza];
		for (int i = 0; i < NumOfPizza; i++) {
			Pizza newpizza = Instantiate(PizzaPrefab) as Pizza;
			pizzas[i] = newpizza;
			newpizza.name = "pizza" + i;
			newpizza.transform.localPosition =
				new Vector3(Random.Range(-xlimit,xlimit), 0, Random.Range(-zlimit,zlimit));
		}
	}
	
	void generate_boss(){
		int xlimit = mapInstance.size.x * 1;
		int zlimit = mapInstance.size.z * 1;

		bosses = new Boss[NumOfBoss];
		for (int i = 0; i < NumOfBoss; i++) {
			Boss newboss = Instantiate(BossPrefab) as Boss;
			bosses[i] = newboss;
			newboss.name = "boss" + i;

			newboss.transform.localPosition =
				new Vector3(Random.Range(-xlimit,xlimit), 0, Random.Range(-zlimit,zlimit));
		}
	}


	
	
}

