using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public int enemyLives;

    void Start()
    {
        enemyLives = 5;
    }


    private void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    {
       
        if (collision.gameObject.CompareTag("Player"))
        {
            if (enemyLives > 1)
            {
                enemyLives--;
                print("Enemy's lives left: " + enemyLives);
            }
            else
            {
                print("Well done!");
                Destroy(gameObject);
            }

        }

        
    }
}
