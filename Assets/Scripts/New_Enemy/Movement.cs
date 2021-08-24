using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] Transform player;
    public float speed;

    private void Awake() {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update() {
        if(player.rotation.z > this.transform.rotation.z) {
            transform.Rotate(Vector3.forward * speed * Time.deltaTime);
        } else if(player.rotation.z < this.transform.rotation.z) {
            transform.Rotate(-Vector3.forward * speed * Time.deltaTime);
        } else if(player.rotation.z == this.transform.rotation.z) {
            transform.Rotate(Vector3.zero);
        }
    }
}
