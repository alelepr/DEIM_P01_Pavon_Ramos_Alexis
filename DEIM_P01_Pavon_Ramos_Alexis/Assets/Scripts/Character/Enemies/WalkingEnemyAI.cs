using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class WalkingEnemyAI : MonoBehaviour
{
    //Referfencia a la vida del enemigo
    private EnemyController enemyController;

    //Referencia al agente
    private AIPath pathAgent;

    [SerializeField] private Transform playerTrf;

    [SerializeField] private float followRange;
    [SerializeField] private LayerMask followLayerMask;

    //Clase enum 
    public enum EnemyState { Iddle, Move, Follow, Attack, Dead }

    private EnemyState state;

    private void Awake()
    {
        pathAgent = GetComponent<AIPath>();
    }

    private void Start()
    {
        enemyController = GetComponent<EnemyController>();
        state = EnemyState.Follow;
    }

    private void Update()
    {   //Si el estado no es muerto
        if (state != EnemyState.Dead)
        {
            //Comprobamos el valor de la vida del enemigo
            if (enemyController.enemyLives <= 0)
            {
                GoToDead();
            }
            else
            {
                switch (state) {

                    case EnemyState.Iddle:
                        if (InFollowRange())
                        {
                            GoToFollow();

                        }
                        else
                        {
                            GoToIddle();
                        }
                        break;
                    case EnemyState.Move:
                        break;

                    case EnemyState.Follow:
                        if (!InFollowRange())
                        {
                            GoToIddle();

                        }else if (InAttackRange())
                        {
                            GoToAttack();
                        }
                        else
                        {
                            //Actualiza en cada frame diciendo que el destino es la posición del jugador
                            pathAgent.destination = playerTrf.position;
                        }
                        break;

                    case EnemyState.Attack:
                        break;

                }
            }
        }

       
    } 
    private void GoToDead()
    {
        state = EnemyState.Dead;
    }
    
    private void GoToIddle()
    {
        state = EnemyState.Iddle;
        pathAgent.canMove = false;

    }

    private void GoToAttack()
    {
        state = EnemyState.Attack;
        pathAgent.canMove = false;

    }

    private void GoToFollow()
    {
        state = EnemyState.Follow;
        pathAgent.canMove = true;
        pathAgent.destination = playerTrf.position;
    }

    private bool InFollowRange() 
    {
        bool res = false;
        //comprobamos con que choca, la posicion del jugador - la posición del enemigo es igual al vector de la direccion del raycast
        RaycastHit2D hit = Physics2D.Raycast(transform.position, playerTrf.position - transform.position, followRange, followLayerMask);
        if ((hit.collider != null) && (hit.collider.CompareTag ("Player"))) //detecta si choca con algo y si con lo que choca es el jugador
        {
            res = true;
        }
        
        return res;
    }
    
    private bool InAttackRange() 
    {
        return false;
    }
}
