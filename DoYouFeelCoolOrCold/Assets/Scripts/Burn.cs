using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burn : MonoBehaviour
{
    private GameObject player;
    [SerializeField] private HealthBar healthBar;
    [SerializeField] private float burningSpeed = 0.05f;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Burning");
            healthBar.ChangeHealthBarValue(healthBar.getHealth() - burningSpeed);
        }
    }
}
