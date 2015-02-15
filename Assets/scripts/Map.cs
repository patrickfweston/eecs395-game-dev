using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Map : MonoBehaviour {

	public IntVector2 size;
	
	public MapCell cellPrefab;
	public Passage passagePrefab;
	public Wall wallPrefab;

	private MapCell[,] cells;

	public float generationStepDelay;

	public MapCell GetCell (IntVector2 coordinates) {
		return cells[coordinates.x, coordinates.z];
	}

	private bool CoordMakeSense(IntVector2 coordinates){
		return (coordinates.x >=0 && coordinates.z >=0 
		        && coordinates.x <size.x && coordinates.z < size.z);
	
	}

	public IEnumerator Generate () {
		WaitForSeconds delay = new WaitForSeconds(generationStepDelay);
		cells = new MapCell[size.x, size.z];
		for (int x = 0; x < size.x; x++) {
			for (int z = 0; z < size.z; z++) {
				yield return delay;
				CreateCell(new IntVector2(x, z));

				MapCell currentCell = cells[x,z];

				foreach(CellDirection direction in Enum.GetValues(typeof(CellDirection))){
					IntVector2 coordinates = currentCell.coordinates + direction.ToIntVector2();
					MapCell neighbor = null;
					if(CoordMakeSense(coordinates)){
						neighbor = GetCell(coordinates);
					}

					if(neighbor != null) {
						CreatePassage(currentCell, neighbor, direction);
					}
				}

			}
		}
	}
	
	private MapCell CreateCell (IntVector2 coordinates) {
		MapCell newCell = Instantiate(cellPrefab) as MapCell;
		cells[coordinates.x, coordinates.z] = newCell;
		newCell.coordinates = coordinates;
		newCell.name = "Map Cell " + coordinates.x + ", " + coordinates.z;
		newCell.transform.parent = transform;
		newCell.transform.localPosition =
			new Vector3(coordinates.x - size.x * 0.5f + 0.5f, -0.5f, coordinates.z - size.z * 0.5f + 0.5f);
		return newCell;
	}

	private void CreatePassage (MapCell cell, MapCell otherCell, CellDirection direction) {
		Passage passage = Instantiate(passagePrefab) as Passage;
		passage.Initialize(cell, otherCell, direction);
		passage = Instantiate(passagePrefab) as Passage;
		passage.Initialize(otherCell, cell, direction.GetOpposite());
	}
	
	private void CreateWall (MapCell cell, MapCell otherCell, CellDirection direction) {
		Wall wall = Instantiate(wallPrefab) as Wall;
		wall.Initialize(cell, otherCell, direction);
		if (otherCell != null) {
			wall = Instantiate(wallPrefab) as Wall;
			wall.Initialize(otherCell, cell, direction.GetOpposite());
		}
	}

}
