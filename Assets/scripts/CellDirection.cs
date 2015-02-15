using UnityEngine;
using System.Collections;

public enum CellDirection {
	North,
	East,
	South,
	West
}

public static class CellDirections {
	
	public const int Count = 4;
	
	private static IntVector2[] vectors = {
		new IntVector2(0, 1),
		new IntVector2(1, 0),
		new IntVector2(0, -1),
		new IntVector2(-1, 0)
	};
	
	public static IntVector2 ToIntVector2 (this CellDirection direction) {
		return vectors[(int)direction];
	}

	private static CellDirection[] opposites = {
		CellDirection.South,
		CellDirection.West,
		CellDirection.North,
		CellDirection.East
	};
	
	public static CellDirection GetOpposite (this CellDirection direction) {
		return opposites[(int)direction];
	}
}
