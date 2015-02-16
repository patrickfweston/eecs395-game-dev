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
		StartCoroutine(BeginGame());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private IEnumerator BeginGame () {
		mapInstance = Instantiate(mapPrefab) as Map;
		yield return StartCoroutine(mapInstance.Generate_map());
		generate_pizza ();
		generate_boss();

	}

	void generate_pizza(){
		float xlimit = 10;
		float zlimit = 10;
		/*float xlimit = mapInstance.size.x * 0.5f - 0.5f;
		float zlimit = mapInstance.size.z * 0.5f - 0.5f;*/
		pizzas = new Pizza[NumOfPizza];
		for (int i = 0; i < NumOfPizza; i++) {
			Pizza newpizza = Instantiate(PizzaPrefab) as Pizza;
			pizzas[i] = newpizza;
			newpizza.name = "pizza" + i;
			newpizza.transform.localPosition =
				new Vector3(Random.Range(-xlimit,xlimit), 0f, Random.Range(-zlimit,zlimit));
		}
	}
	
	void generate_boss(){
		float xlimit = 10;
		float zlimit = 10;
		/*float xlimit = mapInstance.size.x * 0.5f - 0.5f;
		float zlimit = mapInstance.size.z * 0.5f - 0.5f;*/

		bosses = new Boss[NumOfBoss];
		for (int i = 0; i < NumOfBoss; i++) {
			Boss newboss = Instantiate(BossPrefab) as Boss;
			bosses[i] = newboss;
			newboss.name = "boss" + i;
			/*newboss.transform.localPosition =
				new Vector3(Random.Range(-xlimit,xlimit), 0f, Random.Range(-zlimit,zlimit));*/
		}
	}
	
	
}

