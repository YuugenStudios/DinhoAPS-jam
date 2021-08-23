using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    int health = 3;
    public bool socado;
    public void takeDamage()
    {
        
        health--;
        
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

   private void OnTriggerEnter(Collider other) {
      
        if(other.gameObject.tag == "Soco")
        {
            print("socado");
            socado = true;
        }
       
    }
}
