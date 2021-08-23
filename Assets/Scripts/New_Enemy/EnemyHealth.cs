using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
   
    int health = 3;
    public bool socado;
    public GameObject impact;
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
            socado = true;
            Instantiate(impact, other.transform.position, other.transform.rotation);
            
        }
       
    }
}
