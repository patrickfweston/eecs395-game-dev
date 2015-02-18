using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Text;
using System.IO;


public class Map : MonoBehaviour {
	
	public IntVector2 size;
	
	public MapCell cellPrefab;
	public Passage passagePrefab;
	public Wall wallPrefab;
	
	private MapCell[,] cells;
	
	public MapCell GetCell (IntVector2 coordinates) {
		return cells[coordinates.x, coordinates.z];
	}
	
	private MapCell GetNeighbor(MapCell cell, CellDirection direction){
		MapCell neighbor = null;
		IntVector2 coordinates = cell.coordinates + direction.ToIntVector2();
		if(CoordMakeSense(coordinates)) neighbor = GetCell(coordinates);
		return neighbor;
	}
	
	private bool CoordMakeSense(IntVector2 coordinates){
		return (coordinates.x >=0 && coordinates.z >=0 
		        && coordinates.x <size.x && coordinates.z < size.z);
		
	}
	
	public void Generate_floor () {
		cells = new MapCell[size.x, size.z];
		for (int x = 0; x < size.x; x++) {
			for (int z = 0; z < size.z; z++) {
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
	}
	
	private MapCell CreateCell (IntVector2 coordinates) {
		MapCell newCell = Instantiate(cellPrefab) as MapCell;
		cells[coordinates.x, coordinates.z] = newCell;
		newCell.coordinates = coordinates;
		newCell.name = "Map Cell " + coordinates.x + ", " + coordinates.z;
		newCell.transform.parent = transform;
		newCell.transform.localPosition =
			new Vector3(coordinates.x * 2 - size.x, -0.5f, coordinates.z * 2 - size.z );
		return newCell;
	}
	
	private void CreatePassage (MapCell cell, MapCell otherCell, CellDirection direction) {
		if(cell == null) return;

		Passage passage = Instantiate(passagePrefab) as Passage;
		passage.Initialize(cell, otherCell, direction);
		passage = Instantiate(passagePrefab) as Passage;
		passage.Initialize(otherCell, cell, direction.GetOpposite());
	}
	
	private void CreateWall (MapCell cell, MapCell otherCell, CellDirection direction) {
		if(cell == null) return;
		//create 2 walls
//		cell.GetEdge(direction).dest();

		Wall wall = Instantiate(wallPrefab) as Wall;
		wall.Initialize(cell, otherCell, direction);
		wall.transform.localPosition +=
			new Vector3(0, 1, 0);
		
		if (otherCell != null) {
//			otherCell.GetEdge(direction.GetOpposite()).dest();
			wall = Instantiate(wallPrefab) as Wall;
			wall.Initialize(otherCell, cell, direction.GetOpposite());
			wall.transform.localPosition +=
				new Vector3(0, 1, 0);
		}
		
	}

	private void CreateEdge(MapCell cell, CellDirection direction, string wall){
		MapCell neighbor = GetNeighbor(cell, direction);
		if(wall != "0") CreateWall(cell, neighbor, direction);
	}
	
	private void CreateRoom(IntVector2 center, int radius){
//		int edge_cell_num = radius*2+1;
//		bool door = false;
//		//Debug.Log("---------");
//		while(!door){
//			//Debug.Log("====");
//			CreateRoom_(center, radius, ref door, edge_cell_num);
//		}

	}
	
//	private void CreateRoom_(IntVector2 center, int radius,ref bool door, int edge_cell_num){
//		
//		int door_pos = UnityEngine.Random.Range(0, edge_cell_num * 4 - 4 - 1);
//		//Debug.Log(door_pos);
//		
//		IntVector2 coord = center + (CellDirection.North.ToIntVector2() + CellDirection.West.ToIntVector2()) * radius;
//		
//		if(CoordMakeSense(coord)){
//			MapCell NWCell = GetCell(coord);
//			CreateRoomEdge(NWCell, CellDirection.North, edge_cell_num,ref door_pos, ref door);
//		}
//		
//		coord = center +  (CellDirection.North.ToIntVector2() + CellDirection.East.ToIntVector2()) * radius;
//		if(CoordMakeSense(coord)){
//			MapCell NECell = GetCell(coord);
//			CreateRoomEdge(NECell, CellDirection.East, edge_cell_num,ref door_pos, ref door);
//		}
//
//		coord = center +  (CellDirection.East.ToIntVector2() + CellDirection.South.ToIntVector2()) * radius;
//		if(CoordMakeSense(coord)){
//			MapCell ESCell = GetCell(coord);
//			CreateRoomEdge(ESCell, CellDirection.South, edge_cell_num,ref door_pos, ref door);
//		}
//		
//		coord = center +  (CellDirection.South.ToIntVector2() + CellDirection.West.ToIntVector2()) * radius;
//		
//		if(CoordMakeSense(coord)){
//			MapCell SWCell = GetCell(coord);
//			CreateRoomEdge(SWCell, CellDirection.West, edge_cell_num,ref door_pos, ref door);
//		}
//
//	}
//	
//	private void CreateRoomEdge(MapCell startCell, CellDirection direction, int repitition, ref int door_pos, ref bool door){
//
//		IntVector2[] vectors = {
//			new IntVector2(1, 0),
//			new IntVector2(0, -1),
//			new IntVector2(-1, 0),
//			new IntVector2(0, 1)
//		};
//		
//		
//		for(int i = 0; i< repitition; i++,door_pos--){
//			//Debug.Log(i);
//			MapCell neighbor = GetNeighbor(startCell, direction);
//			IntVector2 next = startCell.coordinates + vectors[(int)direction];
//			if(door_pos == 0) {
//				if(neighbor == null){
//					door_pos++;
//				}
//				else {
//					//Debug.Log ("!");
//					
//					startCell.GetEdge(direction).dest();
//					neighbor.GetEdge(direction.GetOpposite()).dest();
//					CreatePassage(startCell, neighbor, direction);
//					if(CoordMakeSense(next)) startCell = GetCell(next);
//					door = true;
//					continue;
//				}
//				
//			}
//			
//			CreateWall (startCell, neighbor, direction);
//			
//			if(CoordMakeSense(next)) startCell = GetCell(next);
//			
//		}
//	}

	public bool load_map_from_file(string fileName){
		try{
			StreamReader theReader = new StreamReader(fileName, Encoding.Default);
			using (theReader){
				string line = null;
				do{
					line = theReader.ReadLine();
					Debug.Log(line);
					if(line.StartsWith("//")) continue;
					string[] entries = line.Split(' ');
					if(entries.Length > 0) Create_map(entries);
				}
				while(line != null);
				theReader.Close();
				return true;
			}
		}
		catch(Exception){
			Debug.Log("wrong reading file");
			return false;

		// From: boss-ai branch
		//		if(!door){
		//			door_pos = UnityEngine.Random.Range(0, edge_cell_num * 4 - 4 - 1);
		//			CreateRooms(center, radius);
		}
	}

	private void Create_map(string[] entries){
		if(entries[0] == "#") {
			Int32.TryParse(entries[1], out size.x);
			Int32.TryParse(entries[2], out size.z);
			Generate_floor();
			return;
		}

		else {
			IntVector2 coord = new IntVector2(-1,-1);
			Int32.TryParse(entries[0], out coord.x);
			Int32.TryParse(entries[1], out coord.z);

			CellDirection[] dirs = {CellDirection.West, CellDirection.North, CellDirection.East,CellDirection.South};
			for(int i = 0; i < 4;i++){
				CreateEdge(GetCell(coord),dirs[i],entries[i+2]);
			}
		}
	}
	
}
