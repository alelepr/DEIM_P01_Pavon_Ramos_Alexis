using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;
[CreateAssetMenu(menuName = "Data/Player Configuration Data")] //para poder crear configuraciones desde el propio unity (nombre de la copia, ruta/nombre en el inspector y orden de aparicion)

public class PlayerConfig : ScriptableObject
{
    //Script que no se puede asignar a los objetos en el inspector, se mantiene en el proyecto
    [Tooltip("Velocidad de movimiento")]
    [Range(0, 10)]
    [SerializeField] private float movementSpeed;

    public RuntimeAnimatorController animatorController;

    public float MovementSpeed
    {
        get
        {
            return movementSpeed;
        }
        /*set
        {
            if (movementSpeed > 0)
            {
                movementSpeed = value;
            }
            else
            {
                Debug.LogError("La velocidad de movimiento no puede ser negativa");
            }

        }*/
    }

   
}
