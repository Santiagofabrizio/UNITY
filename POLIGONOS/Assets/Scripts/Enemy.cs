using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	// Use this for initialization
	private bool dormido = false;

	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (getDormido ()) {
			rigidbody2D.velocity = new Vector2(10f, 0f);
		}
	}

	public void Despertarse() {
		//rigidbody2D.MovePosition (new Vector2 (rigidbody2D.position.x, 5));
		Animator anim = gameObject.GetComponent<Animator> ();
		anim.SetBool ("Despierto", true);
		dormido = true;
		print ("Despertado");
	}

	public void Dormirse() {
		dormido = false;
		Animator anim = gameObject.GetComponent<Animator> ();
		anim.SetBool ("Despierto", true);
		print ("Dormido");
	}

	public bool getDormido() {
		return dormido;

	}
}
