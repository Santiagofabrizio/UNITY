using UnityEngine;
using System.Collections;

public class Hero : MonoBehaviour {

	// Use this for initialization

	public float maxSpeed = 0f;
	public float jumpForce = 2000f;
	public float angle = 30f;
	public float angleVar = 30f;
	private bool rotate = false;
	public bool jump = false;


	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.W) && rigidbody2D.velocity.y == 0 )
		{
			jump = true;
		}
		else
		{
			jump = false;
		}
		if (Input.GetAxis ("Horizontal") != 0) {
			rotate = true;
		} else {
			rotate = false;
		}
	}

	void FixedUpdate() {

		float horizontal = Input.GetAxis ("Horizontal");

		if (rotate) {
			angle = angle + ((-1) * horizontal* angleVar);
			rigidbody2D.MoveRotation (angle);
			rigidbody2D.transform.rotation.Set (0, 0, angle, 0);
		}

		//rigidbody2D.velocity = new Vector2 (maxSpeed * horizontal, rigidbody2D.velocity.y);

		if (jump) { 
				//rigidbody2D.velocity = new Vector2 (rigidbody2D.velocity.x, jumpForce);
				rigidbody2D.AddForce (new Vector2 (rigidbody2D.velocity.x, jumpForce));
		}
		else {
				rigidbody2D.velocity = new Vector2 (rigidbody2D.velocity.x, rigidbody2D.velocity.y);
		}
				
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Enemy") {

			Enemy e = coll.gameObject.GetComponent<Enemy>();
			e.Despertarse();/*
			if (e.getDormido()) {
				e.Dormirse();
				//rigidbody2D.MovePosition(new Vector2(rigidbody2D.position.x, 5));
			} else {
				e.Despertarse();
			}*/
		}
	}
}
