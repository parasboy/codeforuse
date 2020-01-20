using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour {

	public float playerSpeed = 10f;

	Rigidbody rb;
	PlayerAnimation playerAnim;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		playerAnim = GetComponentInChildren<PlayerAnimation> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 movement = (new Vector3 (Input.GetAxisRaw ("Horizontal"), 0, Input.GetAxisRaw ("Vertical"))) * playerSpeed * Time.deltaTime;
		rb.MovePosition (rb.position + movement);

		playerAnim.StateAnimation (Mathf.Abs (movement.z) + Mathf.Abs (movement.x));
	}
}
