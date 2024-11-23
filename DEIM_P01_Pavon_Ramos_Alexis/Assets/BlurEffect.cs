using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlurEffect : MonoBehaviour
{
    public Material blurMaterial;  // Material que usa el Shader de desenfoque
    public float blurSpeed = 1.0f; // Velocidad con la que se aplica el desenfoque
    public float maxBlurAmount = 5.0f; // Cantidad máxima de desenfoque
    private float currentBlurAmount = 0.0f;

    void Start()
    {
        // Si no se asignó un material, intentar obtener el del Renderer
        if (blurMaterial == null)
        {
            var spriteRenderer = GetComponent<SpriteRenderer>();
            blurMaterial = spriteRenderer.material;
        }
    }

    void Update()
    {
        // Cambiar la cantidad de desenfoque
        currentBlurAmount = Mathf.PingPong(Time.time * blurSpeed, maxBlurAmount);

        // Asignar el valor de desenfoque al Shader
        blurMaterial.SetFloat("_BlurAmount", currentBlurAmount);
    }
}
