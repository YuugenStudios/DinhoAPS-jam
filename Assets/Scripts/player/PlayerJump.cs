using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] float jumpForce = 350f, rayHeight = 2.2f;
    [SerializeField] LayerMask groundLayer;
    bool grounded;
    [SerializeField] AudioSource pulo;

    //externals
    private PlayerMovement _playerMoviment;

    void Awake() {
        _playerMoviment = FindObjectOfType<PlayerMovement>();
    }

    void FixedUpdate() {
        // Grounded check
        Ray ray = new Ray(transform.position, -transform.up);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, rayHeight, groundLayer)) {
            grounded = true;
        } else {
            grounded = false;
        }
    }

    public void Jump() {
        if (grounded) {
            _playerMoviment.rb.AddForce(transform.up * jumpForce);
            pulo.Play();
        }
    }
}
