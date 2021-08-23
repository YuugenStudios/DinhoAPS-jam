using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuScript : MonoBehaviour
{
    [SerializeField] public Button playbutton;
    [SerializeField] private Button volumeButton;
    public Sprite volumeOn, volumeOff;
    public Animator animator;

    [SerializeField] Image tutorial;

    private void Awake() {
        AudioListener.volume = 1;
    }

    public void SetVolume(float volume)
    {
        if (AudioListener.volume == 0) {
            AudioListener.volume = 1;
            volumeButton.image.sprite = volumeOn;
        }
        else if (AudioListener.volume == 1) {
            AudioListener.volume = 0;
            volumeButton.image.sprite = volumeOff;
        }
    }

    public void ExitGame() {
        Application.Quit();
    }

    public void OnMouseOver() {
        animator.Play("AnimationPlay");
        Debug.Log("Mouse is over GameObject.");
    }

    public void StartGameScene(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }
}

