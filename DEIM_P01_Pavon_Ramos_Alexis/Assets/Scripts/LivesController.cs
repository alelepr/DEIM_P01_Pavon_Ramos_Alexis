using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LivesController : MonoBehaviour
{
    // Start is called before the first frame update
    public int actualLives;
    public int maxLives = 3;
    public UnityEvent<int> lifeChange;


    void Start()
    {
        actualLives = maxLives;
        lifeChange.Invoke(actualLives);

    }

    
    public void EnemyDamage(int damageAmount)
    {
        int temporalLife = actualLives - damageAmount;
        if (temporalLife < 0)
        {
            actualLives = 0;
        }
        else
        {
            actualLives = temporalLife;
        }
        lifeChange.Invoke(actualLives);


        if (actualLives <= 0) { 
        
            Destroy(gameObject);
        }
    }



    public void Heal(int healAmount)
    {
        int temporalLife = actualLives + healAmount;

        if (temporalLife > maxLives) {

            actualLives = maxLives;
        
        }
        else
        {
            actualLives = temporalLife;
        }
        lifeChange.Invoke(actualLives);

    }


}
