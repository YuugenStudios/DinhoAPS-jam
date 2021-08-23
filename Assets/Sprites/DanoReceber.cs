using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DanoReceber : MonoBehaviour
{
    bool morreu = false;
    public Image playerLifeBar;
    void Start()
    {
        
        playerLifeBar.GetComponent<Image>().fillAmount = 0.75f;
    }
void Update() {

if(playerLifeBar.fillAmount<=0.04f)
{
    morreu = true;
    SceneManager.LoadScene("Game");
}


    
}
  private void OnTriggerEnter(Collider other) {
      
        
        if(other.gameObject.GetComponent<EnemyHealth>().socado == true)
        {
               other.gameObject.GetComponent<EnemyHealth>().socado = false;
        }
        else if(other.gameObject.tag == "Enemy"  )
        {
            
             playerLifeBar.fillAmount -= 0.05f;
           
        }
    }
}
