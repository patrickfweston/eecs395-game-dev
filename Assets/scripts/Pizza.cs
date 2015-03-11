using UnityEngine;
using System.Collections;

public class Pizza : MonoBehaviour {

	public AudioClip Eating_sound;
	
	
	public AudioSource s;
	
	
	void Awake () {
		
//		source = GetComponent<AudioSource>();

	}
	


	IEnumerator OnCollisionEnter(Collision col){
//		Debug.Log ("got pizza");

		if (col.gameObject.name == "Runner") {

			Runner.incrementPizzaBy(1);

//			source.pitch = Random.Range (lowPitchRange,highPitchRange);
//			float hitVol = col.relativeVelocity.magnitude * velToVol;

			s.clip = Eating_sound;
			s.Play();

//			Debug.Log("played sound");
			renderer.enabled = false;
			gameObject.GetComponent<BoxCollider>().enabled = false;
			yield return new WaitForSeconds(s.clip.length);
//			SelfDe
			Destroy(gameObject);
		}
	}

}
