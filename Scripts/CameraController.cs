using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	private PlayerController player;
	private Vector3 offset;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController> ();
		if (player != null) {
			offset = transform.position - player.transform.position;

		}
	}
	
	// Update is called once per frame
	void Update () {
		if (player != null) {
			transform.position = offset + player.transform.position;
		}
	}
}
