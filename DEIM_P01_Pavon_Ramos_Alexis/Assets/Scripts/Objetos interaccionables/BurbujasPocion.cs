using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurbujasPocion : MonoBehaviour
{
    public ParticleSystem burbujas;      // El sistema de partículas para las burbujas
    public float velocidadEmision = 1.0f; // Controla la velocidad de emisión de las burbujas
    public float tamañoMaximo = 0.2f;    // Tamaño máximo de las burbujas
    public float tamañoMinimo = 0.05f;   // Tamaño mínimo de las burbujas
    public float velocidadBurbuja = 1.0f; // Controla la velocidad de las burbujas

    private void Start()
    {
        // Asegurarse de que el sistema de partículas esté asignado
        if (burbujas == null)
        {
            burbujas = GetComponent<ParticleSystem>();
        }

        // Iniciar el sistema de partículas
        if (burbujas != null)
        {
            burbujas.Play();
        }
    }

    private void Update()
    {
        // Si hay partículas
        if (burbujas != null)
        {
            // Modificar la tasa de emisión
            var emission = burbujas.emission;
            emission.rateOverTime = velocidadEmision;

            // Modificar el tamaño de las burbujas
            var main = burbujas.main;
            main.startSize = Mathf.Lerp(tamañoMinimo, tamañoMaximo, Mathf.PingPong(Time.time * velocidadBurbuja, 1));

            // Modificar la velocidad de ascenso de las burbujas
            var velocityOverLifetime = burbujas.velocityOverLifetime;
            velocityOverLifetime.y = velocidadBurbuja;
        }
    }
}
