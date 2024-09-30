using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorController : MonoBehaviour
{
    [SerializeField] private string sceneToLoad; //para serializar la escena y poder indicar en el inspector la escena a la que queremos que nos mande
    private Inventario inventory; //referencia al script de inventario

    private void Start()
    {
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inventory = collision.gameObject.GetComponent<Inventario>(); //hace referencia a un elemento que tiene el propio gameObject, en este caso la puerta
            //para acceder al componente de cualquier objeto viendo en qué momento dos elementos coinciden
            if ( inventory.keyObtained == true)
            {
                print("Tocas la  puerta");
                SceneManager.LoadScene(sceneToLoad);
                inventory.keyObtained = false;
            }
            
        }
    }



}
