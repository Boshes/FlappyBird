using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public static GameController instance;
	public GameObject gameOverText;
	public Text scoreText;
	public Text highscoreText;
	public bool gameOver = false;
	public float scrollSpeed = -1.5f;

	private int highscore = 0;
	private int score = 0;

	// Use this for initialization
	void Awake ()
	{
		if(instance == null)
		{
			highscore = PlayerPrefs.GetInt ("Highscore");
			highscoreText.text = "Highscore: " + highscore.ToString ();
			instance = this;
		}
		else if (instance != this)
		{
			Destroy (gameObject);
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(score >highscore)
		{
			highscore = score;
			PlayerPrefs.SetInt ("Highscore", highscore);
			highscoreText.text = "Highscore: " + highscore.ToString ();
		}
		if(gameOver == true && (Input.GetMouseButton(0) || Input.GetButtonDown("Jump")))
		{
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
		}
	}

	public void BirdScored()
	{
		if(gameOver)
		{
			return;
		}
		score++;
		scoreText.text = "Score: " + score.ToString ();
	}

	public void BirdDied()
	{
		gameOverText.SetActive (true);
		gameOver = true;
	}
}
