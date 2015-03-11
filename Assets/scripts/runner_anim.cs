using UnityEngine;
using System.Collections;

public class runner_anim : MonoBehaviour {

	Animator anim;

	float runSpeed = 1f;
	int walkhash = Animator.StringToHash("walk");
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
//		bool move = Input.GetKey("right")||Input.GetKey("left")||Input.GetKey("up")||Input.GetKey("down");

//		if(move) anim.SetTrigger(walkhash);
		Run ();
	}

	void Run()
	{

//		float d = Input.GetAxis("Vertical")+Input.GetAxis("Horizontal");
//		anim.SetFloat("Run",d);
	}
}
