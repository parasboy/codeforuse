using UnityEngine;
using System.Collections;

public class RaycastShooting : MonoBehaviour {

	public GameObject projectilePrefab;
	public Transform shootPoint;

	void Update () {
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;

		if(Physics.Raycast(ray, out hit, 200f)){
			Vector3 lookPos = new Vector3(hit.point.x, 1f, hit.point.z);
			transform.LookAt(lookPos);
		}

		if (Input.GetMouseButtonDown (0)) {
			Instantiate(projectilePrefab, shootPoint.position, transform.rotation);
		}
	}
}
