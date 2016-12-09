using UnityEngine;
using System.Collections;

public class BallManager : MonoBehaviour {

	public bool hasEntered = false;
    ParticleSystem sparks;

    void OnCollisionEnter(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
            Instantiate(sparks, contact.point, Quaternion.identity);
    }

}
