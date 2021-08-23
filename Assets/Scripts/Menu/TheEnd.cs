using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TheEnd : MonoBehaviour
{
    [SerializeField] float timer;
    void Start() {
        StartCoroutine(GoToMenu("MenuScene"));
    }

    IEnumerator GoToMenu(string sceneName) {
        yield return new WaitForSeconds(timer);
        SceneManager.LoadScene(sceneName);
    }
}
