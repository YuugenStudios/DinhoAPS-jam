using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // public vars
	[SerializeField] float walkSpeed = 6, walkMultipler = 10;
	public float jumpForce = 220;
	public LayerMask groundedMask;
    private bool facingRight;
    [SerializeField] AudioSource soco, pulo;
 
    // System vars
    bool grounded;
	Vector3 moveAmount, targetMoveAmount;
	Vector3 smoothMoveVelocity;
	public Rigidbody rb;

	[SerializeField] GameObject attack;

	//externals
	private PlayerJump _playerJump;
	
	void Awake() {
        facingRight = true;
		rb = GetComponent<Rigidbody>();
		_playerJump = FindObjectOfType<PlayerJump>();
	}
	
	void Update() {

		print(walkSpeed);
		// Calculate movement:
		float inputX = Input.GetAxisRaw("Horizontal");

		if(Input.GetKey(KeyCode.LeftShift) && inputX != 0) {
			Run(inputX);
		}

		targetMoveAmount = new Vector3 (inputX * walkSpeed,0,0);
		moveAmount = Vector3.SmoothDamp(moveAmount,targetMoveAmount,ref smoothMoveVelocity,.15f);
        Flip(inputX);

        // Jump
        if (Input.GetKeyDown(KeyCode.Z)) {
			_playerJump.Jump();
		}

		transform.position = new Vector3(transform.position.x, transform.position.y, 0);

		if (Input.GetKeyDown(KeyCode.X)) {
			soco.Play();
			attack.SetActive(true);
			attack.GetComponent<Animator>().SetTrigger("punch");
		}
	}
	
	void FixedUpdate() {
		Vector3 localMove = transform.TransformDirection(moveAmount) * Time.fixedDeltaTime;
		rb.MovePosition(rb.position + localMove);
	}

    void Flip(float inputX) {
        if (inputX > 0 && !facingRight || inputX < 0 && facingRight) {
            facingRight = !facingRight;
            Vector3 scalePlayer = transform.localScale;
            scalePlayer.x *= -1;
            transform.localScale = scalePlayer;
        }
    }

	void Run(float inputX) {
		//rb.AddForce(transform.right * inputX * walkMultipler);
    }
}
