using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	public int playerHealthMax = 10;

	private int currentPlayerHealth;

	GameManager gameManager;

	// Use this for initialization
	void Start () {
		gameManager = FindObjectOfType<GameManager>();
		currentPlayerHealth = playerHealthMax;

		gameManager.UpdatePlayerHealth (currentPlayerHealth);
	}

	public void TakeDamage (int damage){
		currentPlayerHealth -= damage;
		gameManager.UpdatePlayerHealth (currentPlayerHealth);

		if (currentPlayerHealth <= 0) {
			Die();
		}
	}

	void Die (){
		Destroy (gameObject);
	}
}
