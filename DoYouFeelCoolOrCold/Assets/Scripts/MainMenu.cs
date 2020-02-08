using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        GameObject.Find("PlayButton").SetActive(false);
        GameObject.Find("OptButton").SetActive(false);
        GameObject.Find("QuitButton").SetActive(false);
        StartCoroutine(Waiting());
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    IEnumerator Waiting()
    {
        yield return new WaitForSecondsRealtime(Time.fixedDeltaTime * 5);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
