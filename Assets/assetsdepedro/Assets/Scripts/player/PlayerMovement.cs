using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // public vars
	public float walkSpeed = 6;
	public float jumpForce = 220;
	public LayerMask groundedMask;
    private bool facingRight;

    // System vars
    bool grounded;
	Vector3 moveAmount;
	Vector3 smoothMoveVelocity;
	Rigidbody rigidbody;
	
	
	void Awake() {
        facingRight = true;
		rigidbody = GetComponent<Rigidbody> ();
	}
	
	void Update() {
		
		// Calculate movement:
		float inputX = Input.GetAxisRaw("Horizontal");
		Vector3 targetMoveAmount = new Vector3 (inputX * walkSpeed,0,0);
		moveAmount = Vector3.SmoothDamp(moveAmount,targetMoveAmount,ref smoothMoveVelocity,.15f);
        Flip(inputX);

        // Jump
        if (Input.GetButtonDown("Jump")) {
			if (grounded) {
				rigidbody.AddForce(transform.up * jumpForce);
			}
		}
		
		// Grounded check
		Ray ray = new Ray(transform.position, -transform.up);
		RaycastHit hit;
		
		if (Physics.Raycast(ray, out hit, 1 + .1f, groundedMask)) {
			grounded = true;
		}
		else {
			grounded = false;
		}
		
	}
	
	void FixedUpdate() {
		// Apply movement to rigidbody
		Vector3 localMove = transform.TransformDirection(moveAmount) * Time.fixedDeltaTime;
		rigidbody.MovePosition(rigidbody.position + localMove);
	}

    void Flip(float inputX) // Flipping for the wrong direction! Need to adjust.
    {
        if (inputX > 0 && !facingRight || inputX < 0 && facingRight)
        {
            facingRight = !facingRight;
            Vector3 scalePlayer = transform.localScale;
            scalePlayer.x *= -1;
            transform.localScale = scalePlayer;
        }
    }
}
