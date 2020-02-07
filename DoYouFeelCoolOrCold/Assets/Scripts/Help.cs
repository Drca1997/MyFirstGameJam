using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Help : MonoBehaviour
{
    private GameObject player;
    private string[] helpTexts;
    public TMPro.TextMeshProUGUI helpTextUI;

    private void Awake()
    {
        helpTexts = new string[] { "The sand is hot! Walk in the shadows to keep cold!\n Run pressing shift and the direction key.",
                                   "Careful with walking big distances\n some paths lead nowhere!\nAnd what's with all these beach windbreakers and towels? Can't step on them.",
                                   "See? Nowhere! :(",
                                   "Sometimes, you'll have to get a cooling boost with a drink to be able to get to the next shadow.\nBe sure not to miss it or it could be really bad!",
                                   "And other times, one boost isn't enough!",
                                   "Be sure to fully cool yourself before continuing,\nyou never know when you'll need to walk/run a big distance!",
                                   "Be sure to fully cool yourself before continuing,\nyou never know when you'll need to walk/run a big distance!",
                                   "Damn, beach sure is crowdy today.\nBetter not to touch these people, they're hot from being in the sun for too long.",
                                   "There are a lot of drinks there; maybe i shouldn't drink all of them at once..",
                                   "The cavern are the end of the level, so when you enter them, you advance to the next level!"};
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //meter
            Debug.Log("Meter");
            helpTextUI.SetText(helpTexts[int.Parse(this.name)-1]);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //tirar
            Debug.Log("Tirar");
            helpTextUI.SetText("");
        }
    }
}
