using UnityEngine;
using System.Collections;

public class MouseManager : MonoBehaviour {
	public LineRenderer lineDrag;
	Rigidbody2D grabbedObject; 
	BallManager oGrabbedObject;
	float dragSpeed = 6f;
	
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			
			Vector3 mouseWorldPos3D = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Vector2 mousePos2D = new Vector2(mouseWorldPos3D.x, mouseWorldPos3D.y); 
			Vector2 dir = Vector2.zero;
			
			RaycastHit2D hit = Physics2D.Raycast(mousePos2D, dir); // if we don't hit anything, it will be null
		
			if(hit.collider != null && !hit.collider.GetComponent<BallManager>().hasEntered) { 
				// hit has a reference to collider, which has reference to all collider objects including this
				if(hit.collider.GetComponent<Rigidbody2D>() != null) {	
					
					// technically it doesn't involve any sort of motion/forces so it went here instead of fixedupdate, and that's okay.
					// it means, on the next physics tick (whenever), apply/make sure this is so.
					oGrabbedObject = hit.collider.GetComponent<BallManager>();
					grabbedObject = hit.collider.GetComponent<Rigidbody2D>(); // we just grabbed it.
					grabbedObject.gravityScale = 0;
					lineDrag.enabled = true;
				}
			}
		}
		
		if (Input.GetMouseButtonUp (0) && grabbedObject != null) { // when i lift up the mouse button, don't keep my object glued to it.
			grabbedObject.gravityScale = 1;
			grabbedObject = null;
			lineDrag.enabled = false;
		}
	}
	
	void FixedUpdate() {
		if (grabbedObject != null && !oGrabbedObject.hasEntered) { // then you can move it.
			// for the CONNECTED ANCHOR POINT ON THE MOUSE //
			Vector2 mouseWorldPos2D = Camera.main.ScreenToWorldPoint(Input.mousePosition); 
			grabbedObject.velocity = (mouseWorldPos2D - grabbedObject.position) * dragSpeed;
		}		
	} 
	
	void LateUpdate() { // for purely visual stuff
		if (grabbedObject != null && !oGrabbedObject.hasEntered) {
			Vector3 mouseWorldPos3D = Camera.main.ScreenToWorldPoint (Input.mousePosition); 
			lineDrag.SetPosition (0, new Vector3 (grabbedObject.position.x, grabbedObject.position.y, -1));
			lineDrag.SetPosition (1, new Vector3 (mouseWorldPos3D.x, mouseWorldPos3D.y, -1));
		} else {
			lineDrag.enabled = false;
		}
	}
}