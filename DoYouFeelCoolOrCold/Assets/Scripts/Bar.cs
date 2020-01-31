using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bar : MonoBehaviour
{
    [Tooltip("Referência à camâra para as barras a seguirem")]
    public GameObject camara;

    protected Transform bar;

    private Vector3 offset;

    protected void Start()
    {
        bar = transform.Find("Bar");
        offset = transform.position - camara.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = camara.transform.position + offset;
    }

    public void SetSize(float barsize)
    {
        // Define nível de preenchimento da barra, de 0 a 1.
        bar.localScale = new Vector2(Mathf.Clamp(barsize, 0f, 1f), 1f);
    }

    //inutil,uma vez que faremos com a transparencia
    public void ChangeColor(Color new_color)
    {
        SpriteRenderer barsprite = gameObject.GetComponentInChildren<SpriteRenderer>();
        if (barsprite == null)
        {
            Debug.Log("Componente Sprite Renderer não encontrado");
            return;
        }
        barsprite.color = new_color;
        

    }

}
