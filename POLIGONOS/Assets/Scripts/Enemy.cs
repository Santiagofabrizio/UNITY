using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	// Use this for initialization
	private bool dormido = true;

	void Start () {
	
	}

	void Update() {
		Animator anim = gameObject.GetComponent<Animator> ();
		dormido = !anim.GetCurrentAnimatorStateInfo(0).IsName("Enojado");

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (!getDormido ()) {
			rigidbody2D.velocity = new Vector2(3f, 0f);
		}
	}

	public void Despertarse() {
		//rigidbody2D.MovePosition (new Vector2 (rigidbody2D.position.x, 5));
		Animator anim = gameObject.GetComponent<Animator> ();
		anim.SetBool ("Despierta", true);
		dormido = false;
		print ("Despertado");
	}

	public void Dormirse() {
		dormido = true;
		Animator anim = gameObject.GetComponent<Animator> ();
		anim.SetBool ("Despierta", true);
		print ("Dormido");
	}

	public bool getDormido() {
		return dormido;

	}
}
