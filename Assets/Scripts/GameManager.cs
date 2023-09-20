using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public static GameManager instance;

	public bool IsGameOver { get; private set; }

	public TextMeshProUGUI scoreText;
	public GameObject gameOverText;

	private int score = 0;

	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
			gameOverText.SetActive(false);
		}
		else
		{
			Debug.LogWarning("GameManager instance already exists, destroying this one.");
			Destroy(gameObject);
		}
	}

	private void Update()
	{
		if (IsGameOver && Input.GetMouseButtonDown(0))
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
	}

	public void AddScore(int newScore)
	{
		if (IsGameOver)
			return;

		score += newScore;
		scoreText.text = $"SCORE : {score}";
	}

	public void OnPlayerDead()
	{
		IsGameOver = true;
		gameOverText.SetActive(true);
	}
}
