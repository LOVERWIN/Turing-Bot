using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class BotonRefrescoController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    // Referencias
    private Vector3 originalPosition;
    public AudioClip sonidoPresion;   // Sonido para cuando el bot�n es presionado
    private AudioSource audioSource;
    private Renderer buttonRenderer;  // Para manipular el material del bot�n
    private ActivarObjectController activarObjectController;
    private AutomataController automataController;
    private AdjustCameraPosition adjustCameraPosition;
    // Emisi�n original del material

    private const string audioPath = "sonidos/caja_fuerte_tecla_variante_2";
    private Color originalEmissionColor;

    void Start()
    {
        // Guardamos la posici�n original del bot�n
        originalPosition = transform.position;

        // Referencia al componente de audio
        // Obtener el componente AudioSource
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Cargar el audio desde la carpeta Resources
        sonidoPresion = Resources.Load<AudioClip>(audioPath);
        if (sonidoPresion == null)
        {
            Debug.LogError($"No se encontr� el archivo de audio en la ruta: {audioPath}");
        }

        // Referencia al componente Renderer para manipular el material del bot�n
        buttonRenderer = GetComponent<Renderer>();

        // Guardar el color original de emisi�n del material (si existe)
        if (buttonRenderer != null && buttonRenderer.material.HasProperty("_EmissionColor"))
        {
            originalEmissionColor = buttonRenderer.material.GetColor("_EmissionColor");
        }
        activarObjectController = FindObjectOfType<ActivarObjectController>();
        automataController = FindAnyObjectByType<AutomataController>();
        adjustCameraPosition = FindAnyObjectByType<AdjustCameraPosition>();

    }

    // M�todo para manejar cuando el bot�n es presionado (t�ctil o clic)
    public void OnPointerDown(PointerEventData eventData)
    {
        // Aumentar la emisi�n para que el bot�n brille
        if (buttonRenderer != null && buttonRenderer.material.HasProperty("_EmissionColor"))
        {
            buttonRenderer.material.SetColor("_EmissionColor", Color.white);  // Cambio de emisi�n a blanco brillante
            DynamicGI.SetEmissive(buttonRenderer, Color.white);  // Aseguramos que la emisi�n se actualice correctamente
        }

        // Mover el bot�n ligeramente hacia atr�s para simular que se presiona
        transform.position = originalPosition - new Vector3(0, 0, 0.01f);

        // Reproducir sonido al presionar
        if (sonidoPresion != null)
        {
            audioSource.PlayOneShot(sonidoPresion);
        }

        BotonPresionado();
        // Llamar al m�todo para despachar la botella correspondiente
        
    }

    public void BotonPresionadonew()
    {
        // Aumentar la emisi�n para que el bot�n brille
        if (buttonRenderer != null && buttonRenderer.material.HasProperty("_EmissionColor"))
        {
            buttonRenderer.material.SetColor("_EmissionColor", Color.white);  // Cambio de emisi�n a blanco brillante
            DynamicGI.SetEmissive(buttonRenderer, Color.white);  // Aseguramos que la emisi�n se actualice correctamente
        }

        // Mover el bot�n ligeramente hacia atr�s para simular que se presiona
        transform.position = originalPosition - new Vector3(0, 0, 0.01f);

        // Reproducir sonido al presionar
        if (sonidoPresion != null)
        {
            audioSource.PlayOneShot(sonidoPresion);
        }

        BotonPresionado();
        // Llamar al m�todo para despachar la botella correspondiente

    }

    public void BotonDejoPresionar()
    {
        // Restaurar la posici�n del bot�n
        transform.position = originalPosition;

        // Restaurar la emisi�n original del bot�n
        if (buttonRenderer != null && buttonRenderer.material.HasProperty("_EmissionColor"))
        {
            buttonRenderer.material.SetColor("_EmissionColor", originalEmissionColor); // Restaurar el color original de emisi�n
            DynamicGI.SetEmissive(buttonRenderer, originalEmissionColor); // Aseguramos que la emisi�n se actualice correctamente
        }
    }

    // M�todo para manejar cuando el bot�n deja de ser presionado
    public void OnPointerUp(PointerEventData eventData)
    {
        // Restaurar la posici�n del bot�n
        transform.position = originalPosition;

        // Restaurar la emisi�n original del bot�n
        if (buttonRenderer != null && buttonRenderer.material.HasProperty("_EmissionColor"))
        {
            buttonRenderer.material.SetColor("_EmissionColor", originalEmissionColor); // Restaurar el color original de emisi�n
            DynamicGI.SetEmissive(buttonRenderer, originalEmissionColor); // Aseguramos que la emisi�n se actualice correctamente
        }
    }

    // M�todo que llama a tu l�gica de despachar botella
    private void BotonPresionado()
    {
     

        // Obtener el tag del bot�n
        string tagBoton = gameObject.tag;
        // Encontrar el GameObject con el tag proporcionado
      

        // Usamos un switch o if/else para identificar qu� refresco despachar

        switch (tagBoton)
        {
            case "btn_jamaica":
                
                // Llamar al m�todo para despachar el refresco
                Debug.Log("btn_jamaica");
                AccederByTagName("fila-1-2");

                break;
            case "btn_fresa":
                // Llamar al m�todo para despachar Sprite
                Debug.Log("btn_fresa");
                AccederByTagName("fila-3-3");
                break;
            case "btn_limonada":
                // Llamar al m�todo para despachar Fanta
                AccederByTagName("fila-2-2");
                Debug.Log("btn_limonada");
                break;
            case "btn_naranja":
                // Llamar al m�todo para despachar Fanta
                AccederByTagName("fila-2-3");
                Debug.Log("btn_naranja");
                break;
            case "btn_pina":
                AccederByTagName("fila-2-1");
                // Llamar al m�todo para despachar Fanta
                Debug.Log("btn_pina");
                break;
            case "btn_pozol":

                AccederByTagName("fila-1-1");
                // Llamar al m�todo para despachar Fanta
                Debug.Log("btn_pozol");

                break;
            case "btn_sandia":
                AccederByTagName("fila-3-2");
                // Llamar al m�todo para despachar Fanta
                Debug.Log("btn_sandia");
                break;
            case "btn_tamarindo":
                AccederByTagName("fila-1-3");
                // Llamar al m�todo para despachar Fanta
                Debug.Log("btn_tamarindo");
                break;
            case "btn_tascalate":
                AccederByTagName("fila-3-1");
                // Llamar al m�todo para despachar Fanta
                Debug.Log("btn_tascalate");
                break;
            // Agregar m�s casos seg�n los refrescos
            default:
                Debug.LogWarning("Tag no reconocido");
                break;
        }
    }

    


    private void AccederByTagName(string tag)
    {
       // adjustCameraPosition.RestaurarPosicionCamera();
        GameObject boquilla_monedero = GameObject.FindWithTag("boquilla_monedero");


        if (boquilla_monedero != null)
        {
            // Obtener el script FilaController del objeto encontrado
            
            ColisionCoin colisionCoin = boquilla_monedero.GetComponent<ColisionCoin>();
            if (colisionCoin != null)
            {
                // if (AdjustCameraPosition.activaAnimacionCamera)
                // {
                //     return;
                // }

                if (colisionCoin.contador < 20)
                {
                    Debug.Log("Contador insuficiente: " + colisionCoin.contador);
                    audioSource.clip = Resources.Load<AudioClip>("sonidos/CreditoInsuficiente");
                    audioSource.Play();
                    return;
                }
                else
                {
                    // Encontrar el GameObject con el tag proporcionado
                    GameObject fila = GameObject.FindWithTag(tag);
                    if (fila != null)
                    {
                        // Obtener el script FilaController del objeto encontrado
                        FilaController filacontroller = fila.GetComponent<FilaController>();
                        if (filacontroller != null)
                        {

                            if (FilaController.activaAnimacion != true)
                            {
                                

                                // Llamar al m�todo para despachar la botella
                                // Llamar al m�todo para despachar la botella
                                colisionCoin.contador -= 20;

                                if (colisionCoin.contador > 0)
                                {
                                    Debug.Log("Cambio: "+colisionCoin.contador);
                                    audioSource.clip = Resources.Load<AudioClip>("sonidos/cambio5pesos");
                                    audioSource.Play();
                                    colisionCoin.contador = 0;
                                }
                                activarObjectController.ReactivarObjetos();
                                automataController.ResetearAutomata();

                                // colisionCoin.contador = 0;
                                colisionCoin.ContadorText.text = "$" + colisionCoin.contador.ToString();

                                //Debug.Log("Despachando refresco para el tag: " + tag);

                                filacontroller.DespacharBotella();
                                //Debug.Log("Despachando refresco para el tag: " + tag);
                            }
                            else
                            {
                                Debug.Log("No entro a despachar");
                            }

                        }
                        else
                        {
                            Debug.LogError("No se encontr� el script FilaController en el objeto con tag: " + tag);
                        }
                    }
                    else
                    {
                        Debug.LogError("No se encontr� un objeto fila con el tag: " + tag);
                    }
                }

                
            }
            else
            {
                Debug.LogError("No se encontr� el script FilaController en el objeto con tag: " + tag);
            }
        }
        else
        {
            Debug.LogError("No se encontr� un objeto con el tag: " + tag);
        }
        
    }
}
