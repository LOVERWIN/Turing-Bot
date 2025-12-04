using UnityEngine;
using TMPro; // ¡Nuevo namespace necesario!

public class ScrollingTex : MonoBehaviour
{
    public TMP_Text textComponent;  // TextMesh Pro
    public string fullText = "¡Todo a $20 pesos!";
    public float scrollSpeed = 0.5f; // Velocidad ajustada para World Space

    private float textWidth;
    private RectTransform textRect;
    private float canvasWidth; // Ancho del Canvas en unidades world space

    void Start()
    {
        // Configura el texto inicial
        textComponent.text = fullText;
        textRect = textComponent.GetComponent<RectTransform>();

        // Calcula el ancho del texto y el Canvas
        textWidth = textComponent.preferredWidth;
        canvasWidth = GetComponent<RectTransform>().rect.width;

        // Posición inicial: derecha del Canvas
        textRect.anchoredPosition = new Vector2(canvasWidth, 0);
    }

    void Update()
    {
        textRect.anchoredPosition -= new Vector2(scrollSpeed * Time.deltaTime, 0);

        // Reinicia solo cuando el texto esté completamente fuera
        if (textRect.anchoredPosition.x <= -textWidth)
        {
            textRect.anchoredPosition = new Vector2(canvasWidth, 0);
        }
    }
}