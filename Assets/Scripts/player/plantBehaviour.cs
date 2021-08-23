using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class plantBehaviour : MonoBehaviour
{
     [SerializeField] float cooldown;
    [SerializeField] int valorToAdd;
    int clorofilaEnergy = 20;
    [SerializeField] TMP_Text clorofilaEnergyText;

    bool facingSun;
    [SerializeField] LayerMask plantLayer;

    private CallScene _callScene;
     
    private void Awake() {
     _callScene = FindObjectOfType<CallScene>();
    }
    private void Start() {
        InvokeRepeating("ManageEnergy", 0.2f, cooldown);
    }

    private void Update() {
        clorofilaEnergyText.text = clorofilaEnergy.ToString() + "%";
    }

    private void FixedUpdate() {
        Ray ray = new Ray(transform.position, transform.up);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, Mathf.Infinity,plantLayer)) {
            facingSun = true;
        } else if(!Physics.Raycast(ray, out hit, Mathf.Infinity,plantLayer)) {
            facingSun = false;
        }
    }

    void ManageEnergy() {
        if(facingSun) {
            if(clorofilaEnergy < 100) {
                clorofilaEnergy += valorToAdd;
            }
            else if(clorofilaEnergy >=100) {
                SceneManager.LoadScene("Win");
            }
        } else if(!facingSun) {
            if(clorofilaEnergy >0) {
                clorofilaEnergy -= valorToAdd;
            } else if( clorofilaEnergy <=0) {
              SceneManager.LoadScene("GameOver");
            }
        }
    }

}
