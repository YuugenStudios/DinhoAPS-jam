using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerJump : MonoBehaviour
{

    [SerializeField] private Vector3 jumpDirection;
    [SerializeField] string groundTag;
    private bool onGround;

    private playerBehaviour _playerBehaviour;

    private void Awake() {
        _playerBehaviour = FindObjectOfType<playerBehaviour>();
    }
    
    public void Jump() {
        if(onGround) {
            _playerBehaviour.rb.AddForce(jumpDirection * _playerBehaviour.JumpForce);
            onGround = false;
        }
    }

    private void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.tag == groundTag) {
            onGround = true;
        }
    }

}
