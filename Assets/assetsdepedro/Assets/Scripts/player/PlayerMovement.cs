using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    public float moveSpeed;
    float inputX;
    
    void Start()
    {
        
    }

    void Update()
    {
        inputX = Input.GetAxisRaw("Horizontal");

        if (inputX == 0)
        {
            rb.velocity = new Vector3(0, rb.velocity.y, 0);
        }
    }

    void FixedUpdate()
    {
        rb.AddForce(transform.right * inputX * moveSpeed);
    }

    void OnTriggerStay(Collider obj)
    {
        if (obj.CompareTag("Planet"))
        {
            obj.GetComponent<Rigidbody>().drag = 1f;
        }
    }

    void OnTriggerExit(Collider obj)
    {
        if (obj.CompareTag("Planet"))
        {
            obj.GetComponent<Rigidbody>().drag = .2f;
        }
    }
}
