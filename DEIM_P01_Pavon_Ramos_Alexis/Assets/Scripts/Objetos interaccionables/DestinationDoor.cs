using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestinationDoor : MonoBehaviour
{
    //[SerializeField] private string sceneToLoad; //para serializar la escena y poder indicar en el inspector la escena a la que queremos que nos mande
    private Inventario inventory; //referencia al script de inventario
    public Transform mainDoor; // Arrastra la puerta de destino en el Inspector
    public Camera targetCamera; // Cámara de destino
    public Camera activeCamera; // Cámara de destino
    [SerializeField] private GameObject player;
    public CinemachineVirtualCamera virtualCamera; // Cámara virtual de Cinemachine



    private void Start()
    {
        virtualCamera.Follow = player.transform;
        targetCamera = GameObject.Find("MainCamera").GetComponent<Camera>();
        activeCamera = GameObject.Find("CapillaCamera").GetComponent<Camera>();
        GameObject doorObject = GameObject.Find("Door");
        mainDoor = doorObject.GetComponent<Transform>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            
            collision.transform.position = new Vector2(mainDoor.position.x + 1, mainDoor.position.y);
            activeCamera.gameObject.SetActive(false); // Desactiva la cámara actual
            targetCamera.gameObject.SetActive(true); // Activa la cámara de destino
                
           
        }

    }
}


