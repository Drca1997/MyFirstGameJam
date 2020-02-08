using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        GameObject.Find("MainMenu").SetActive(false);
        StartCoroutine(Waiting());
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(10);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
