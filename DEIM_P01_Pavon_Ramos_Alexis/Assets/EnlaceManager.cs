using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class EnlaceManager : MonoBehaviour, IPointerClickHandler
{
    private TextMeshProUGUI textComponent;

    void Start()
    {
        textComponent = GetComponent<TextMeshProUGUI>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        string link = textComponent.textInfo.linkInfo[0].GetLinkID(); // Obtén el enlace
        if (link.StartsWith("http")) // Verifica si es una URL
        {
            Application.OpenURL(link); // Abre la URL en el navegador
        }
    }
}
