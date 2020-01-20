using UnityEngine;
using System.Collections;

public class DestroyParticles : MonoBehaviour {

	public float secondsToDestroy = 1f;

	// Use this for initialization
	void Start () {
		StartCoroutine (DestroyParticle ());
	}

	IEnumerator DestroyParticle (){
		yield return new WaitForSeconds (secondsToDestroy);
		Destroy (gameObject);
	}
}
