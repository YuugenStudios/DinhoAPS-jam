using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseController : MonoBehaviour
{
    [SerializeField] GameObject pauseCanva;
    public bool isPaused;

    // Update is called once per frame
    void Update() {
        if(Input.GetKeyDown(KeyCode.Escape)) {
            PauseManager();
        }
    }

    public void PauseManager() {
        if (isPaused) {
            Time.timeScale = 1f;
            pauseCanva.SetActive(false);
            isPaused = false;  
        } else if(!isPaused) {
            Time.timeScale = 0;
            pauseCanva.SetActive(true);
            isPaused= true;
        }
    }
}
