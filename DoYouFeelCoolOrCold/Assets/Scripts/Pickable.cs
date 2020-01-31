using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : MonoBehaviour
{
    private GameObject player;
    [Tooltip("Referência ao objecto da Barra de Vida, para poder mudar o valor do X dela")]
    [SerializeField]private HealthBar healthBar;

    [Tooltip("Quanto o pickup fornece de vida")]
    public float bonus;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            
            Debug.Log("Apanhou uma monster");
            healthBar.ChangeHealthBarValue(healthBar.getHealth() + bonus);
            //gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }

}
