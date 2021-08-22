using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityBody : MonoBehaviour
{
	GravityAtractor planet;
	[SerializeField] Rigidbody rb;
	
	void Awake () {
		planet = GameObject.FindObjectOfType<GravityAtractor>();

		rb.useGravity = false;
		rb.constraints = RigidbodyConstraints.FreezeRotation;
	}
	
	void FixedUpdate () {
		// Allow this body to be influenced by planet's gravity
		planet.Attract(rb);
	}
}
