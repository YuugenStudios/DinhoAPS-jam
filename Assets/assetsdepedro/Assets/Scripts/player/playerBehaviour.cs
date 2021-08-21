using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerBehaviour : MonoBehaviour {

    //player atributes
    [SerializeField] public Rigidbody rb;
    [SerializeField] private float rotationVelocity;
    [SerializeField] public float JumpForce;
    [SerializeField] private Vector3 rotationDirection;

    [SerializeField] Transform world;

    //externals 
    private playerJump _playerJump;

    private void Awake()
    {
        _playerJump = FindObjectOfType<playerJump>();
    }
    void Update() {
        if (Input.GetButtonDown("Jump") && Input.GetKeyDown(KeyCode.Space)) {
            _playerJump.Jump();
        }

        float xInput = Input.GetAxisRaw("Horizontal") * Time.deltaTime;

        this.transform.RotateAround(world.position, rotationDirection, xInput * rotationVelocity);
    }
}
