using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogBox : MonoBehaviour
{
    private GameObject player;
    private string[] helpTexts;
    public TMPro.TextMeshProUGUI dialogTextUI;
    public GameObject spacePressUI;
    private static bool in_dialog;

    private void Awake()
    {
        helpTexts = new string[] {"Hey-o Mike, las night was wack dude!",
                                  "You gotta go home now tho, so be sure to catch the ice cream van.",
                                  "How do you get there? You'll just find at the end of the different beaches.",
                                  "Aight, bye dude.",
                                  "Hey, wait a minute! Be careful dude, i don't know how much of an hangover you have, but don't forget you're a snowman.",
                                  "The sand is hot and if you're on it for too long, you're gonna melt.",
                                  "Be sure to walk on the shadows or catch a drink on your wait to the cavern to keep cool."};
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine("DialogueS");
        }
    }

    public static bool checkDialog()
    {
        return in_dialog;
    }

    IEnumerator DialogueS()
    {
        in_dialog = true;
        Time.timeScale = 0f;
        PauseMenu.GameIsPaused = true;
        spacePressUI.SetActive(true);
        int current = 0;
        Debug.Log(helpTexts[current]);
        dialogTextUI.SetText(helpTexts[current]);
        while (current + 1 < helpTexts.Length)
        {
            current++;
            yield return StartCoroutine(WaitForEnter());
            Debug.Log(helpTexts[current]);
            dialogTextUI.SetText(helpTexts[current]);
        }
        spacePressUI.SetActive(false);
        dialogTextUI.SetText("");
        Time.timeScale = 1f;
        PauseMenu.GameIsPaused = false;
        in_dialog = false;
    }

    IEnumerator WaitForEnter()
    {
        do
        {
            yield return null;
        } while (!Input.GetKeyDown(KeyCode.Space));
    }
}
