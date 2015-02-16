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

	private MapCell GetNeighbor(MapCell cell, CellDirection direction){
		MapCell neighbor = null;
		IntVector2 coordinates = cell.coordinates + direction.ToIntVector2();
		if(CoordMakeSense(coordinates)) neighbor = GetCell(cell.coordinates);
		return neighbor;
	}

	private bool CoordMakeSense(IntVector2 coordinates){
		return (coordinates.x >=0 && coordinates.z >=0 
		        && coordinates.x <size.x && coordinates.z < size.z);
	
	}

	public IEnumerator Generate_map () {
		WaitForSeconds delay = new WaitForSeconds(generationStepDelay);
		cells = new MapCell[size.x, size.z];
		for (int x = 0; x < size.x; x++) {
			for (int z = 0; z < size.z; z++) {
				yield return delay;
				CreateCell(new IntVector2(x, z));

				MapCell currentCell = cells[x,z];

				foreach(CellDirection direction in Enum.GetValues(typeof(CellDirection))){

					MapCell neighbor = GetNeighbor(currentCell, direction);
					if(neighbor != null) {
						CreatePassage(currentCell, neighbor, direction);
					}
				}
			}
		}

		IntVector2 Center = new IntVector2(5,5);
		CreateRooms(Center , 3);
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
		if(cell == null) return;
		//create 2 walls
		Wall wall = Instantiate(wallPrefab) as Wall;
		wall.Initialize(cell, otherCell, direction);
		wall.transform.localPosition +=
			new Vector3(0, 0.5f, 0);

		if (otherCell != null) {
			wall = Instantiate(wallPrefab) as Wall;
			wall.Initialize(otherCell, cell, direction.GetOpposite());
		}
		wall.transform.localPosition +=
			new Vector3(0, 0.5f, 0);
	}

	private void CreateRooms(IntVector2 center, int radius){
		int edge_cell_num = radius*2+1;
		int door_pos = UnityEngine.Random.Range(0, edge_cell_num * 4 - 4);
		Debug.Log (door_pos);

		IntVector2 coord = center +  (CellDirection.North.ToIntVector2() + CellDirection.West.ToIntVector2()) * radius;
		MapCell NWCell = GetCell(coord);
		coord = center +  (CellDirection.North.ToIntVector2() + CellDirection.East.ToIntVector2()) * radius;
		MapCell NECell = GetCell(coord);
		coord = center +  (CellDirection.East.ToIntVector2() + CellDirection.South.ToIntVector2()) * radius;
		MapCell ESCell = GetCell(coord);
		coord = center +  (CellDirection.South.ToIntVector2() + CellDirection.West.ToIntVector2()) * radius;
		MapCell SWCell = GetCell(coord);

		CreateRoomEdge(NWCell, CellDirection.East, edge_cell_num,ref door_pos);
		CreateRoomEdge(NECell, CellDirection.South, edge_cell_num,ref door_pos);
		CreateRoomEdge(ESCell, CellDirection.West, edge_cell_num,ref door_pos);
		CreateRoomEdge(SWCell, CellDirection.North, edge_cell_num,ref door_pos);
	
	}

	private void CreateRoomEdge(MapCell startCell, CellDirection direction, int repitition, ref int door_pos){


		IntVector2[] vectors = {
			new IntVector2(1, 0),
			new IntVector2(0, -1),
			new IntVector2(-1, 0),
			new IntVector2(0, 1)
		};

		for(int i = 0; i< repitition; i++, door_pos--){
			Debug.Log (door_pos);
			if(door_pos != 0) {
				MapCell neighbor = GetNeighbor(startCell, direction);
				CreateWall (startCell, neighbor, direction);
			}


			startCell = GetCell(startCell.coordinates + vectors[(int)direction]);
		}
	}

}
