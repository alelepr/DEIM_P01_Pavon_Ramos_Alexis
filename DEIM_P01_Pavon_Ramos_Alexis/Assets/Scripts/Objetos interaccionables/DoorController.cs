using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorController : MonoBehaviour
{
    //[SerializeField] private string sceneToLoad; //para serializar la escena y poder indicar en el inspector la escena a la que queremos que nos mande
    private Inventario inventory; //referencia al script de inventario
    public Transform targetDoor; // Arrastra la puerta de destino en el Inspector
    [SerializeField] public Camera targetCamera; // Cámara de destino
    [SerializeField] public Camera activeCamera; // Cámara de destino



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
                if (collision.gameObject.tag == "Player") // Asegúrate de que el jugador tenga esta etiqueta
                {
                    collision.transform.position = new Vector2(targetDoor.position.x - 1, targetDoor.position.y);
                    activeCamera.gameObject.SetActive(false); // Desactiva la cámara actual
                    targetCamera.gameObject.SetActive(true); // Activa la cámara de destino
                }
                inventory.keyObtained = false;
            }
            
        }
    }


}
