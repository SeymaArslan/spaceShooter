using UnityEngine.UI;
using UnityEngine;
using System.Collections;


public class GameController : MonoBehaviour
{  
	public GameObject hazard;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;


	public GUIText scoreText;
	//public GUIText restartText;
	public GUIText gameOverText;
	public GUIText highscoreText;


	private bool gameOver;
	//private bool restart;
	private int score;
	private int highscore;

	Text text;


	void Start ()
	{  
		gameOver = false;
		//restart = false;
		//restartText.text = "";
		gameOverText.text = "";
		score = 0;
		Updatehighscore ();
		UpdateScore ();
		StartCoroutine (SpawnWaves ());

		text =GetComponent<Text>();
		text = GetComponent<Text> ();

		highscore = PlayerPrefs.GetInt ("highscore", highscore);




	}


	void Update ()
	{
		if (score > highscore) {

			highscore = score;
			highscoreText.text = "HIGH SCORE " + highscore;
		
			PlayerPrefs.SetInt("highscore", highscore);


		}




		if (score == 100) 
		{
			Application.LoadLevel (2);
			Time.timeScale = 1;

		}
		/*if (restart) {
			if (Input.GetKeyDown (KeyCode.P)) {
			

			}*/


		
	}



	IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds (startWait);
		while (true)
		{
			for (int i = 0; i < hazardCount; i++)
			{
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);
			}
			
			yield return new WaitForSeconds (waveWait);
			
		/*	if (gameOver)
			{

				restartText.text = "Press 'P' for Restart";
				restart = true;
				break;
		    } */


			}
	}


	public void AddScore (int newScoreValue)
	{
		score += newScoreValue;
	
		if (score > highscore) 
		{ 
			highscore = score;
			highscore += newScoreValue;
			highscore = newScoreValue;
		}
		UpdateScore ();
		Updatehighscore();
	}
	
	void UpdateScore ()
	{
		scoreText.text = "SCORE: " + score;
	}

   void Updatehighscore ()
	{  

	  highscoreText.text = "HIGHSCORE:" + highscore;


	}

	


	public void GameOver ()
	{   
		gameOverText.text = "Game Over..!";
		gameOver = true;
	}

	void OnDestroy()
	{
	    PlayerPrefs.Save();
		PlayerPrefs.SetInt ("Highscore", highscore);


    }



}


