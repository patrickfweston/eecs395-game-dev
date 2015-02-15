using UnityEngine;

public abstract class CellEdge : MonoBehaviour {
	
	public MapCell cell, otherCell;
	
	public CellDirection direction;

	public void Initialize (MapCell cell, MapCell otherCell, CellDirection direction) {
		this.cell = cell;
		this.otherCell = otherCell;
		this.direction = direction;
		cell.SetEdge(direction, this);
		transform.parent = cell.transform;
		transform.localPosition = Vector3.zero;
	}
}