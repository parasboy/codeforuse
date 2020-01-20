using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ProjectileBehaviour : MonoBehaviour {

	public float force = 2000f;

	Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		rb.AddForce (transform.forward * force);

		StartCoroutine (DestroyAfterSeconds ());
	}

	IEnumerator DestroyAfterSeconds (){
		yield return new WaitForSeconds (1f);
		Destroy (gameObject);
	}
}
