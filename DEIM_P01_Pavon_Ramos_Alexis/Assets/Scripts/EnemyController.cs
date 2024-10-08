using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public GameObject player;
    public int lives;

    void Start()
    {
        //player = GameObject.Find("Player");
        //lives = GameObject.Find("Player").GetComponent<lives>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       /* if (collision.gameObject.CompareTag("Player"))
        {

            if (collision.gameObject.CompareTag("Player"))
            {
                if (player.lives > 1)
                {
                    player.lives--;
                    print("Lives left: " + player.lives);
                }
                else
                {
                    print("You died");
                    Destroy(collision.gameObject);
                }

            }


        }*/
    }
}
