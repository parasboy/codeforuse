using UnityEngine;
using System.Collections;

public class PlayerAnimation : MonoBehaviour {

	public GameObject gunGraphic;

	Animator anim;
	int playerStateHash = Animator.StringToHash("Speed");

	// Use this for initialization
	void Start () {
		anim = GetComponentInChildren<Animator> ();
	}

	public void StateAnimation(float speed){
		anim.SetFloat (playerStateHash, speed);

		if (speed < 0.1 && speed > -0.1) {
			gunGraphic.SetActive(false);
		}

		if (speed > 0.1 || speed < -0.1) {
			gunGraphic.SetActive(true);
		}
	}
}
