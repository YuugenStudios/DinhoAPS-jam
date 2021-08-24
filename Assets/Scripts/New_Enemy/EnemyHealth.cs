using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
   
    int health = 2;
    public bool socado;
    public GameObject impact;
    //[SerializeField] ParticleSystem deathParticles;

    Spawner _spawner;

    private void Awake() {
        _spawner = FindObjectOfType<Spawner>();
    }
    public void takeDamage()
    {
        
        health--;
        
        if (health <= 0) {
            //deathParticles.Play();	
            _spawner.activeEnemies--;
            Destroy(this.gameObject);
        }
    }
   
   private void OnTriggerEnter(Collider other) {
      
        if(other.gameObject.tag == "Soco") {
            socado = true;
            Instantiate(impact, other.transform.position, other.transform.rotation);          
        }
       
    }
}
