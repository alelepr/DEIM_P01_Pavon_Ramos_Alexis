using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;


public class LuzVidriera : MonoBehaviour
{
    public Light2D luzVidriera;          // Componente Light2D del GameObject
    public float intensidadBase = 1.0f;  // Intensidad base de la luz
    public float variacionMinima = 0.95f;  // Variación mínima de la intensidad
    public float variacionMaxima = 1.05f;  // Variación máxima de la intensidad
    public float velocidadFluctuacion = 0.5f;  // Velocidad de fluctuación de la intensidad

    private void Start()
    {
        // Asegurarse de que el componente Light2D está asignado
        if (luzVidriera == null)
        {
            luzVidriera = GetComponent<Light2D>();
        }
    }

    private void Update()
    {
        // Variar suavemente la intensidad de la luz dentro de un rango determinado
        float variacion = Mathf.Lerp(variacionMinima, variacionMaxima, Mathf.PerlinNoise(Time.time * velocidadFluctuacion, 0));
        luzVidriera.intensity = intensidadBase * variacion;
    }
}
