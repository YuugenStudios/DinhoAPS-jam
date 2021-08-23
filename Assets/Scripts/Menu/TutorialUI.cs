using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialUI : MonoBehaviour
{
    [SerializeField] GameObject tutorial;
    [SerializeField] GameObject Interface;

    void Start()
    {
        tutorial.SetActive(true);
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextTutorial() {
        tutorial.SetActive(false);
        Interface.SetActive(true);
        Time.timeScale = 1;
    }
}
