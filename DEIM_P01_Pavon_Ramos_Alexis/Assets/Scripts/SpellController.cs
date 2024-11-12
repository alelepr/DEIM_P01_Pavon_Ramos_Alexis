using UnityEngine;

public class SpellController : MonoBehaviour
{
    // Variable para almacenar la cantidad de hechizos
    public int spellCount = 10;

    private void Start()
    {
        // Inicialización si es necesario
        Debug.Log("Hechizos iniciales: " + spellCount);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica si el objeto que colisiona es el jugador
        if (other.CompareTag("Player"))
        {
            // Suma 5 hechizos
            AddSpells(5);
            // Destruye el objeto o desactívalo (opcional)
            Destroy(gameObject);
        }
    }

    public void AddSpells(int amount)
    {
        spellCount += amount;
        Debug.Log("Hechizos actuales: " + spellCount);
    }
}
