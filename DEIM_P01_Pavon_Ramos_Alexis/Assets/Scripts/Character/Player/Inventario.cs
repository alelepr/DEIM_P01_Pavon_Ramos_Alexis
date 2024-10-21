using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventario : MonoBehaviour
{
    public bool keyObtained; // al ser publica puedo leer la variable en el script de la puerta

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Key"))
        {
            print("Tocas la  llave");
            keyObtained = true;
            Destroy(collision.gameObject);


        }
    }
  

}
