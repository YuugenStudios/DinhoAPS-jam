using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldController : MonoBehaviour
{
    [SerializeField] Transform world;
    [SerializeField] float worldRotationVelocity; 

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {
        float xInput = Input.GetAxisRaw("Horizontal") * Time.deltaTime;

        world.Rotate(transform.forward, xInput * worldRotationVelocity);
    }
}
