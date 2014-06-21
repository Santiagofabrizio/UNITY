using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	// Use this for initialization
	private bool dormido = true;
	private float velocity = -10f;
	private float timer = 0f;
	void Start () {
	
	}

	void Update() {
		Animator anim = gameObject.GetComponent<Animator> ();
		dormido = !anim.GetCurrentAnimatorStateInfo(0).IsName("Enojado");
		timer += Time.deltaTime;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		/*
		 * El cuadrado se despierta y empieza a ir de un lado a otro. 
		 * cambia el sentido de avance, cuando choca con otro enemico
		 * o cuando pasa una cierta cantidad de tiempo o cuando llega al final
		 * del piso.
		 **/
		if (!getDormido ()) {

			rigidbody2D.velocity = new Vector2(velocity, 0f);

		}

	
	}

	public void Despertarse() {
		//rigidbody2D.MovePosition (new Vector2 (rigidbody2D.position.x, 5));
		Animator anim = gameObject.GetComponent<Animator> ();
		anim.SetBool ("Despierta", true);
		dormido = false;
		flip ();
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

	public void flip() {
		Vector3 flip = transform.localScale;
		flip.x *= -1;
		velocity *= -1;
		transform.localScale = flip;
	}
}


