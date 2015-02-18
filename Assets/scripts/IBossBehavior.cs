using UnityEngine;
using System.Collections;

public interface IBossBehavior {

	// delegate function for boss to call to handle collision
	void collideWithPlayer();

	// called during fixed update in boss
	void Update(Boss b);

}
