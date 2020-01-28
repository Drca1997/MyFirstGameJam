using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : Bar
{
    [SerializeField]private float health = 0.5f;
    private Transform red_bar;
    private new void Start()
    {
        base.Start();
        red_bar = transform.Find("Red_Bar");
        ChangeHealthBarValue(health);
    }

    public void Update()
    {
        health = 1 - bar.localScale.x;
        //só pra testar
        test_health_change();
    }

    public void ChangeHealthBarValue(float health)
    {
        SetSize(1 - health);
        red_bar.localScale = new Vector2(Mathf.Clamp(1 - health, 0f, 1f), 1f);

       
        SpriteRenderer barsprite = bar.GetComponentInChildren<SpriteRenderer>();
        Color temp = barsprite.color;
        temp.a = health;
       
        barsprite.color = temp;
        Debug.Log(barsprite.color.a);
    }

    //só pra testar
    public void test_health_change()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ChangeHealthBarValue(health - 0.1f);
        }
    }


}
