using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeIA : MonoBehaviour
{
    [SerializeField]
    float speed, life; // Primeira variavel é a velocidade do slime e a segunda é a vida
    [HideInInspector]
    GameObject player; // Aqui vai o player pra a I.A conseguir localizar ele... 

    bool direita;
                        
    void Awake() 
    {   
        player = GameObject.FindGameObjectWithTag("Player"); //Acha o player pela tag

        if(player.transform.position.x < transform.position.x){direita = true;} //diz que o slimer nasceu na direita
        else{direita = false; //diz que o slimer nasceu na Esquerda
        transform.localScale = new Vector3(transform.localScale.x *-1, transform.localScale.y, transform.localScale.z); 
            //inverte a Escala do transform
        } 
        
    

    }
    void FixedUpdate()
    {
        if(player.transform.position.x < transform.position.x && !direita) //vê se o inimigo está na direita olhando pra direita
        {
            transform.localScale = new Vector3(transform.localScale.x *-1, transform.localScale.y, transform.localScale.z); 
            //inverte a Escala do transform
            direita = true;
        }
        else if(player.transform.position.x > transform.position.x && direita) //vê se o inimigo está na esquerda olhando pra esquerda
        {
            transform.localScale = new Vector3(transform.localScale.x *-1, transform.localScale.y, transform.localScale.z); 
            //inverte a Escala do transform
            direita = false;
        }

        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        //Faz ESSE transform seguir em direção ao transform cujo o transform player pegou as caracteristicas
        //Mas em vez de só teleportar para o local ele faz isso aos poucos e na velocidade de SPEED

    }
}
