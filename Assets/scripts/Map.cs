using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Map : MonoBehaviour {

	public IntVector2 size;
	
	public MapCell cellPrefab;

	private MapCell[,] cells;

	public float generationStepDelay;
	
	public IEnumerator Generate () {
		WaitForSeconds delay = new WaitForSeconds(generationStepDelay);
		cells = new MapCell[size.x, size.z];
		for (int x = 0; x < size.x; x++) {
			for (int z = 0; z < size.z; z++) {
				yield return delay;
				CreateCell(new IntVector2(x, z));
			}
		}
	}
	
	private void CreateCell (IntVector2 coordinates) {
		MapCell newCell = Instantiate(cellPrefab) as MapCell;
		cells[coordinates.x, coordinates.z] = newCell;
		newCell.coordinates = coordinates;
		newCell.name = "Map Cell " + coordinates.x + ", " + coordinates.z;
		newCell.transform.parent = transform;
		newCell.transform.localPosition =
			new Vector3(coordinates.x - size.x * 0.5f + 0.5f, -0.5f, coordinates.z - size.z * 0.5f + 0.5f);
	}

}
