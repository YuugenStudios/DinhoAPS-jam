using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityAtractor : MonoBehaviour
{
	public float gravity = -9.8f;

	public void Attract(Rigidbody body) {
		Vector3 gravityUp = (body.position - transform.position).normalized;
		Vector3 localUp = body.transform.up;
		
		// Apply downwards igravity to body
		body.AddForce(gravityUp * gravity);
		// Allign bodies up axis with the centre of planet
		body.rotation = Quaternion.FromToRotation(localUp,gravityUp) * body.rotation;
	}  
}
