using UnityEngine;
using System.Collections;

public class ObjectSpawnerScript : MonoBehaviour {

	public GameObject[] balls;
	public float nextFire = 1f;
	public float fireDelay = 10f;
	public int minFireVelocity = 5;
	public int maxFireVelocity = 10;

	void Start () {
		if (balls == null) {
			Debug.LogError("No assigned ball objects!");
		}
	}
	
	void FixedUpdate () {
		int chosenIndex, chosenFireVelocity;
		float randomSideways;
		nextFire -= Time.deltaTime;

		if (nextFire <= 0) {
			nextFire = fireDelay;
			chosenIndex = Random.Range (0, balls.Length);
			randomSideways = Random.Range (-2f, 2f);
			GameObject ball = (GameObject) GameObject.Instantiate (balls [chosenIndex],
			                                          transform.position + new Vector3(randomSideways, 0, 0),
			                                          transform.rotation);
			ball.GetComponent<Rigidbody2D>().isKinematic = false;
			chosenFireVelocity = Random.Range(minFireVelocity, maxFireVelocity);
			ball.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -chosenFireVelocity);
		}
	}
}
