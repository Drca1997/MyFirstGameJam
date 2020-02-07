using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class deathMenu : MonoBehaviour
{
    public void Restart()
    {
        SceneManager.LoadScene(Application.loadedLevel + 1);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
