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

	private static Vector3[] vectors3 = {
		new Vector3(0,0, 1),
		new Vector3(1,0, 0),
		new Vector3(0, 0,-1),
		new Vector3(-1,0, 0)
	};

	private static Quaternion[] rotations = {
		Quaternion.identity,
		Quaternion.Euler(0f, 90f, 0f),
		Quaternion.Euler(0f, 180f, 0f),
		Quaternion.Euler(0f, 270f, 0f)
	};

	private static Quaternion[] rotations_inward = {
		Quaternion.Euler(0f, 180f, 0f),
		Quaternion.Euler(0f, 270f, 0f),
		Quaternion.identity,
		Quaternion.Euler(0f, 90f, 0f)
	};
	
	public static Quaternion ToRotation (this CellDirection direction) {
		return rotations[(int)direction];
	}
	public static Quaternion ToRotation_in (this CellDirection direction) {
		return rotations_inward[(int)direction];
	}
	
	public static IntVector2 ToIntVector2 (this CellDirection direction) {
		return vectors[(int)direction];
	}
	public static Vector3 ToVector3 (this CellDirection direction) {
		return vectors3[(int)direction];
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
