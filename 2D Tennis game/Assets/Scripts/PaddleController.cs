using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour {

	public float speed;

	float direction; // ball direction for speed up

	public float adjustSpeed;

	// objects for paddle movement limitation
	public Transform upperLimit;
	public Transform lowerLimit;

	public bool isPlayerOne; // cheking for single or multiplayer mode

	public bool isAI;
	public BallController theBall;

	// Use this for initialization
	void Start () {
		theBall = FindObjectOfType<BallController> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (isAI) {

			transform.position = Vector3.MoveTowards (transform.position, new Vector3 (transform.position.x, theBall.transform.position.y, transform.position.z), speed * Time.deltaTime );

		} else {

			if (isPlayerOne) {
				// Movement statements
				if (Input.GetKey (KeyCode.W)) {
					// Moving up
					transform.position = new Vector3 (transform.position.x, transform.position.y + (speed * Time.deltaTime), transform.position.z);
					direction = 1;

				} else if (Input.GetKey (KeyCode.S)) {
					// Moving down
					transform.position = new Vector3 (transform.position.x, transform.position.y - (speed * Time.deltaTime), transform.position.z);
					direction = -1;

				} else {
					direction = 0;
				}
			} else {
				// Movement statements
				if (Input.GetKey (KeyCode.UpArrow)) {
					// Moving up
					transform.position = new Vector3 (transform.position.x, transform.position.y + (speed * Time.deltaTime), transform.position.z);
					direction = 1;

				} else if (Input.GetKey (KeyCode.DownArrow)) {
					// Moving down
					transform.position = new Vector3 (transform.position.x, transform.position.y - (speed * Time.deltaTime), transform.position.z);
					direction = -1;

				} else {
					direction = 0;
				}
			}

		}

		// paddle movement limitation statements
		if (transform.position.y > upperLimit.position.y) {
			transform.position = new Vector3 (transform.position.x, upperLimit.position.y, transform.position.z);
		} else if (transform.position.y < lowerLimit.position.y) {
			transform.position = new Vector3 (transform.position.x, lowerLimit.position.y, transform.position.z);
		}
	}

	// this method is called when the gameobjects get collided
	void OnCollisionExit2D (Collision2D col){
		// ball movement and speed statements while it get touched with paddle
		col.rigidbody.velocity = new Vector2 (col.rigidbody.velocity.x * 1.1f, col.rigidbody.velocity.y + (direction * adjustSpeed));
	
	}
}
