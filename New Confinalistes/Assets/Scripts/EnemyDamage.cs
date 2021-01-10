using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int health;
    public int speed;
    //This is to give a visual efect to the enemy when hit -> public GameObject bloodEffect;
    private float stunedTime;
    public float startStunedTime;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(stunedTime <= 0)
        {
            speed = 1;
        }
        else
        {
            speed = 0;
            stunedTime -= Time.deltaTime;
        }

        if(health <= 0)
        {
            Destroy(gameObject);
        }
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    public void TakeDamage(int damage)
    {
        stunedTime = startStunedTime;
        //This is to give a visual efect to the enemy when hit -> Instantiate(bloodEffect, transform.position, Quaternion.identity);
        health -= damage;
    }
}
