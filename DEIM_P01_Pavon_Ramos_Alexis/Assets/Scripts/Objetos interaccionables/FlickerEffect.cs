using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FlickerEffect : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;  // Referencia al SpriteRenderer de la llama
    public float minAlpha = 0.3f;          // Opacidad mínima de la llama
    public float maxAlpha = 1.0f;          // Opacidad máxima de la llama
    public float flickerSpeed = 0.2f;      // Velocidad del parpadeo
    public float flickerAmount = 0.1f;     // Cantidad del parpadeo

    private float targetAlpha;

    void Start()
    {
        // Inicializamos el SpriteRenderer
        if (spriteRenderer == null)
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        // Inicializamos la opacidad de la llama
        targetAlpha = Random.Range(minAlpha, maxAlpha);
        SetAlpha(targetAlpha);
    }

    void Update()
    {
        // Realiza un cambio aleatorio en la opacidad para simular el parpadeo
        if (Random.Range(0f, 1f) < flickerSpeed * Time.deltaTime)
        {
            targetAlpha = Random.Range(minAlpha, maxAlpha);
        }

        // Interpolación suave entre la opacidad actual y la opacidad objetivo
        float currentAlpha = spriteRenderer.color.a;
        float newAlpha = Mathf.Lerp(currentAlpha, targetAlpha, flickerAmount);
        SetAlpha(newAlpha);
    }

    // Método para ajustar la opacidad
    void SetAlpha(float alpha)
    {
        Color color = spriteRenderer.color;
        color.a = alpha;
        spriteRenderer.color = color;
    }
}