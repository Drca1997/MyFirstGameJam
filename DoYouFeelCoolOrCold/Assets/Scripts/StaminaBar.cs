using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaBar : MonoBehaviour
{
    private Transform bar;
    // Start is called before the first frame update
    void Start()
    {
        bar = transform.Find("Bar");
    }

    public void SetSize(float barsize)
    {
        // Define nível de preenchimento da barra, de 0 a 1.
        bar.localScale = new Vector2(Mathf.Clamp(barsize, 0f, 1f), 1f);
    }
}
