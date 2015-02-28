using UnityEngine;

public class MapCell : MonoBehaviour {

	public IntVector2 coordinates;
	public bool hasdesk = false;

	private CellEdge[] edges = new CellEdge[CellDirections.Count];
	
	public CellEdge GetEdge (CellDirection direction) {
		return edges[(int)direction];
	}
	
	public void SetEdge (CellDirection direction, CellEdge edge) {
		edges[(int)direction] = edge;
	}
}