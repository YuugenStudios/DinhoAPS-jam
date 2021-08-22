using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuScript : MonoBehaviour
{
    [SerializeField] private Button volumeButton;

    private void Awake() {
        AudioListener.volume = 1;
    }

    public void SetVolume(float volume)
    {
        if (AudioListener.volume == 0) {
            AudioListener.volume = 1;
            volumeButton.image
        }
        else if (AudioListener.volume == 1) {
            AudioListener.volume = 0;
        }
    }

    public void ExitGame() {
        Application.Quit();
    }
}

