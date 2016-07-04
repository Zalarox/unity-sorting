using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelManagerScript : MonoBehaviour {

	public GameObject BGM;	
	public static int correct, incorrect, score;
	public Text tScore, tCorrect, tIncorrect;

	public void Start() 
	{
		if (BGM == null) {
			tScore.text = score.ToString ();
			tCorrect.text = correct.ToString ();
			tIncorrect.text = incorrect.ToString ();
		}
	}

	public void ResetScore() 
	{
		correct = 0; incorrect = 0; score = 0;
	}

	public void StartTheGame() 
	{
		GameObject.DontDestroyOnLoad (BGM);
		ResetScore ();
		Application.LoadLevel ("game");
	}

	public void GameOver()
	{
		Application.LoadLevel ("results");
	}
}
