using UnityEngine;
using System.Collections;

public class EnemyAnimation : MonoBehaviour {

	Animator anim;
	int attackPlayerHash = Animator.StringToHash("Attack");
	int deathPlayerHash = Animator.StringToHash("Death");

	// Use this for initialization
	void Start () {
		anim = GetComponentInChildren<Animator> ();
	}

	public void AttackAnimation (bool isAttacking){
		anim.SetBool (attackPlayerHash, isAttacking);
	}

	public void DeathAnimation (){
		anim.SetTrigger (deathPlayerHash);
	}
}
