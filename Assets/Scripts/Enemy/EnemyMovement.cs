using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour {

    //[SerializeField] NavMeshAgent agente;
    [SerializeField] Transform player;
    [SerializeField] Transform world;
    [SerializeField] float inimigoSpeed;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        world = GameObject.FindGameObjectWithTag("Planet").transform;
    }

    void Update()
    {
        //agente.SetDestination(player.position);

        if (true) {
            transform.RotateAround(world.position, new Vector3(0, 0, 1), inimigoSpeed);

        }
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
    }
}
