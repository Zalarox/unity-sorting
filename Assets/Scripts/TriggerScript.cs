using UnityEngine;
using System.Collections;

public class TriggerScript : MonoBehaviour {
	public AudioClip correctSound, incorrectSound;
	public static int correct, incorrect, score;
	public int colourID = 0;
	public Animator plusOne, minusOne;

	void OnTriggerEnter2D(Collider2D collider)
	{
		collider.GetComponent<Rigidbody2D> ().gravityScale = 1;
		collider.GetComponent<BallManager> ().hasEntered = true;
		if (colourID == 0) 
		{
			if(collider.tag.Equals("Red")) 
			{
				correct++;
				AudioSource.PlayClipAtPoint(correctSound, transform.position);
				plusOne.Play("Float");
			}
			else 
			{
				incorrect++;
				AudioSource.PlayClipAtPoint(incorrectSound, transform.position);
				minusOne.Play("Float");
			}
		}
		else if (colourID == 1)
		{
			if(collider.tag.Equals("Blue"))
			{
				correct++;
				AudioSource.PlayClipAtPoint(correctSound, transform.position);
				plusOne.Play("Float");
			}
			else
			{
				incorrect++;
				AudioSource.PlayClipAtPoint(incorrectSound, transform.position);
				minusOne.Play("Float");
			}
		}
		Debug.Log ("Total: " + (incorrect + correct));
		if (incorrect + correct == 10) 
		{
			score = correct*150-incorrect*100;
			if(score<0) {
				score = 0;
			}
			LevelManagerScript.correct = correct;
			LevelManagerScript.incorrect = incorrect;
			LevelManagerScript.score = score;
			Application.LoadLevel("results");
			correct = 0;
			incorrect = 0;
			score = 0;
		}
	}
}
