using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {

	public GameObject deathParticles;
	public GameObject[] deathDecals;
	public Vector2 speedMinMax;
	public float attackDelay = 0.25f;

	private NavMeshAgent aiAgent;
	private GameManager gameManager;
	private EnemyAnimation enemyAnim;
	private PlayerHealth player;
	private Vector3 playerPosition;

	float nextAttackTime;
	bool canChase;
	bool canAnimate = true;

	// Use this for initialization
	void Start () {
		aiAgent = GetComponent<NavMeshAgent> ();
		gameManager = FindObjectOfType<GameManager> ();
		enemyAnim = GetComponentInChildren<EnemyAnimation> ();
		player = FindObjectOfType<PlayerHealth> ();

		aiAgent.speed = Random.Range (speedMinMax.x, speedMinMax.y);

		canChase = true;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (player != null) {
			playerPosition = player.transform.position;

		}

		if (canChase) {
			aiAgent.SetDestination(playerPosition);
		}
				
		if (Vector3.Distance (playerPosition, transform.position) <= 1.5f && player != null && canChase) {
			Attack ();
		} else {
			enemyAnim.AttackAnimation (false);
		}
	}

	GameObject SelectDecal(){
		GameObject decal = deathDecals [Random.Range (0, deathDecals.Length)];
		return decal;
	}

	void Attack (){
		if (Time.time >= nextAttackTime) {
			player.TakeDamage (1);
			enemyAnim.AttackAnimation (true);
			nextAttackTime = Time.time + attackDelay;
		}
	}

	void OnTriggerEnter (Collider other){
		if (other.CompareTag ("Bullet")) {
			if(canAnimate){
				gameManager.UpdatePlayerScore(1);
				enemyAnim.DeathAnimation();
				Instantiate(deathParticles, transform.position, Quaternion.identity);
				Instantiate(SelectDecal(), transform.position, transform.rotation);
			}
			canChase = false;
			canAnimate = false;
			StartCoroutine(Death());
		}
	}

	IEnumerator Death (){
		yield return new WaitForSeconds(2);
		Destroy(gameObject);

	}
}
