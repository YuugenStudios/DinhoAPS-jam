using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeIA : MonoBehaviour
{
    [SerializeField]
    float speed, life; // Primeira variavel é a velocidade do slime e a segunda é a vida
    [SerializeField]
    GameObject player; // Aqui vai o player pra a I.A conseguir localizar ele... 
                        
    void Awake() 
    {
    player = GameObject.FindGameObjectWithTag("Player");
    }
    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        //Faz ESSE transform seguir em direção ao transform cujo o transform player pegou as caracteristicas
        //Mas em vez de só teleportar para o local ele faz isso aos poucos e na velocidade de SPEED

    }
}
