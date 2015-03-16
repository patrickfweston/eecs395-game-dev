using UnityEngine;
using System.Collections;

public class Manager : MonoBehaviour {

	//prefas
	public Map mapPrefab;
	public Boss BossPrefab;
	public Pizza PizzaPrefab;
	public Light l;

	public static bool changelight =false;

	//member varaibles
	private Map mapInstance;
	private Pizza[] pizzas;
	private Boss[] bosses;
	private int original_num_pizza;
	public int NumOfPizza;
	public int NumOfBoss;

	// Use this for initialization
	void Start () {
		original_num_pizza = NumOfPizza;
		l = gameObject.GetComponentsInChildren<Light>()[0];
		BeginGame();
	}
	
	// Update is called once per frame
	void Update () {
		if(changelight) l.color = Color.Lerp(l.color, Color.red, Time.deltaTime);
		else l.color = Color.white;

		if(NumOfPizza == 0){
			NumOfPizza = original_num_pizza;
			generate_pizza();
		}
	}

	private void BeginGame () {
		mapInstance = Instantiate(mapPrefab) as Map;
		mapInstance.load_map_from_file("Assets/map_data");
		generate_pizza ();
		generate_boss();

	}


	void generate_pizza(){

		pizzas = new Pizza[NumOfPizza];
		for (int i = 0; i < NumOfPizza; i++) {
			Pizza newpizza = Instantiate(PizzaPrefab) as Pizza;
			pizzas[i] = newpizza;
			newpizza.name = "pizza";
			int indexx = Random.Range(0, mapInstance.size.x-1);
			int indexz = Random.Range(0, mapInstance.size.z-1);
			MapCell tmp = mapInstance.GetCell(new IntVector2(indexx,indexz));

			while(tmp.hasdesk){
				indexx = Random.Range(0, mapInstance.size.x-1);
				indexz = Random.Range(0, mapInstance.size.z-1);
				tmp = mapInstance.GetCell(new IntVector2(indexx,indexz));
//				Debug.Log("!!");
			}

			newpizza.transform.localPosition = tmp.transform.localPosition;
		}
	}
	
	void generate_boss(){
		bosses = new Boss[NumOfBoss];
		for (int i = 0; i < NumOfBoss; i++) {
			Boss newboss = Instantiate(BossPrefab) as Boss;
			bosses[i] = newboss;
			newboss.name = "boss" + i;
			int indexx = Random.Range(0, mapInstance.size.x-1);
			int indexz = Random.Range(0, mapInstance.size.z-1);
			MapCell tmp = mapInstance.GetCell(new IntVector2(indexx,indexz));
			
			while(tmp.hasdesk){
				indexx = Random.Range(0, mapInstance.size.x-1);
				indexz = Random.Range(0, mapInstance.size.z-1);
				tmp = mapInstance.GetCell(new IntVector2(indexx,indexz));
				Debug.Log("!!");
			}


			newboss.transform.localPosition = new Vector3(tmp.transform.localPosition.x, 0.5f, tmp.transform.localPosition.z);


//			newboss.transform.localPosition = tmp.transform.localPosition;
		}
	}


	
	
}

