using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;


public class Llamadevela : MonoBehaviour
{
    public Light2D luzVela;          // Componente Light2D del GameObject
    public float intensidadMinima = 0.5f;  // Intensidad mínima de la llama
    public float intensidadMaxima = 1.5f;  // Intensidad máxima de la llama
    public float velocidadFluctuacion = 0.1f;  // Velocidad de fluctuación de la intensidad

    private void Start()
    {
        // Asegurarse de que el componente Light2D está asignado
        if (luzVela == null)
        {
            luzVela = GetComponent<Light2D>();
        }
    }

    private void Update()
    {
        // Cambiar la intensidad de la luz de forma aleatoria para simular la llama
        luzVela.intensity = Mathf.Lerp(intensidadMinima, intensidadMaxima, Mathf.PerlinNoise(Time.time * velocidadFluctuacion, 0));
    }
}

