using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public GameObject gameOverPanel;
	public Text healthText;
	public Slider healthBar;
	public Text scoreText;
	public Text timeText;

	private int playerHealth;
	private int playerScore = 0;

	// Use this for initialization
	void Start () {
		healthBar.maxValue = playerHealth;
		SetHealthUI ();
		SetScoreUI ();
	}

	public void UpdatePlayerHealth(int health){
		playerHealth = health;
		SetHealthUI ();

		if (playerHealth <= 0) {
			gameOverPanel.SetActive(true);
			SetTimeUI();
		}
	}

	public void UpdatePlayerScore(int score){
		playerScore += score;
		SetScoreUI ();
	}

	void SetHealthUI () {
		healthText.text = "HEALTH " + playerHealth.ToString ();
		healthBar.value = playerHealth;
	}

	void SetScoreUI () {
		scoreText.text = playerScore.ToString ();
	}

	void SetTimeUI () {
		timeText.text = Time.time.ToString ("0");
	}

	public void RestartLevel(){
		Application.LoadLevel (0);
	}
	
}
