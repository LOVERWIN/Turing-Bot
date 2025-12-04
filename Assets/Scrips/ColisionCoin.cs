using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class ColisionCoin : MonoBehaviour
{
    public int contador = 0; // Contador de monedas
    //[SerializeField] private GameObject moneda5_cambio;
    private AudioSource audioSource;
    public AudioClip sonidoPresion;   // Sonido para cuando el bot�n es presionado
    private const string audioPath = "sonidos/coin-drops-and-spins-272429";
    public TextMeshProUGUI ContadorText;
    Quaternion nuevaRotacion = Quaternion.Euler(0f, 179.015f, 0f);
    private RotateCoin rotateCoin;
    private AutomataController automataController;
    private ActivarObjectController activarObjectController;
    //private AdjustCameraPosition adjustCameraPosition;
    private void Start()
    {
        rotateCoin = GetComponent<RotateCoin>();
        // Buscar el objeto padre que tiene el script AutomataController
        automataController = FindObjectOfType<AutomataController>();
        activarObjectController = FindObjectOfType<ActivarObjectController>();
       // adjustCameraPosition = FindAnyObjectByType<AdjustCameraPosition>();
        automataController.CambiarMaterial("q0_inicio_inactivo", 2);

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

        // moneda5_cambio = GameObject.Find("Moneda5_cambio");
        // moneda5_cambio.SetActive(false);

    }

   
    IEnumerator ReactivarMoneda(GameObject moneda)
    {
        yield return new WaitForSeconds(1f); // Espera antes de reaparecer
        moneda.SetActive(true); // Reactivar la moneda
    }
    void OnTriggerEnter(Collider other)
    {
        //DragHandler dragHandler = other.GetComponent<DragHandler>();
       // starPositionMoneda = dragHandler.savedPosition;
        if (other.gameObject.CompareTag("Coin_10"))
        {
            activarObjectController.RestablecerCoin10();
            // Reproducir sonido al presionar
            if (sonidoPresion != null)
            {
                audioSource.PlayOneShot(sonidoPresion);
            }
            contador += 10;
            validarConteoMoendas(contador, "Coin_10");
            ContadorText.text = "$"+contador.ToString();
            Debug.Log("Trigger detectado con la moneda");
           // dragHandler.TerminarArrastre();
         

        }
        else if(other.gameObject.CompareTag("Coin_5"))
        {
            activarObjectController.RestablecerCoin5();
            // Reproducir sonido al presionar
            if (sonidoPresion != null)
            {
                audioSource.PlayOneShot(sonidoPresion);
            }
            contador += 5;
            validarConteoMoendas(contador, "Coin_5");
            ContadorText.text = "$"+contador.ToString();
            //dragHandler.TerminarArrastre();

        }

        if (contador>=20)
        {
            Debug.Log("Entrando al metodo mayor que 20");
            activarObjectController.DesactivarObjetos();
            //adjustCameraPosition.MoveCamera();
        }


    }

    public void validarConteoMoendas(int contador,string tag_moneda)
    {
        

        switch (contador) { 
            case 0:
                break;
            case 5:
                automataController.CambiarMaterial("q0_inicio_inactivo", 14);
                automataController.CambiarMaterial("q1_inactivo", 4);
                automataController.CambiarMaterial("transicion_q0_q1", 0);
                Debug.Log("q1");
                break;
            case 10:
                automataController.CambiarMaterial("q2_inactivo", 6);
                if (tag_moneda.Equals("Coin_10"))
                {
                    automataController.CambiarMaterial("transicion_q0_q2", 0);
                    automataController.CambiarMaterial("q0_inicio_inactivo", 14);
                }
                else
                {
                    automataController.CambiarMaterial("transicion_q1_q2", 0);
                    automataController.CambiarMaterial("q1_inactivo", 15);

                }

                break;
            case 15:
                automataController.CambiarMaterial("q3_inactivo", 8);
                if (tag_moneda.Equals("Coin_10"))
                {
                    automataController.CambiarMaterial("transicion_q1_q3", 0);
                    automataController.CambiarMaterial("q1_inactivo", 15);
                }
                else
                {
                    automataController.CambiarMaterial("transicion_q2_q3", 0);
                    automataController.CambiarMaterial("q2_inactivo", 16);
                }

                break;
            case 20:
                automataController.CambiarMaterial("q4_aceptacion_inactivo", 10);

                if (tag_moneda.Equals("Coin_10"))
                {
                    automataController.CambiarMaterial("transicion_q2_q4", 0);
                    automataController.CambiarMaterial("q2_inactivo", 16);

                }
                else
                {
                    automataController.CambiarMaterial("transicion_q3_q4", 0);
                    automataController.CambiarMaterial("q3_inactivo", 17);
                }

                break;
            case 25:
                automataController.CambiarMaterial("transicion_q3_q4", 0);
                automataController.CambiarMaterial("q4_aceptacion_inactivo", 10);
                automataController.CambiarMaterial("q3_inactivo", 17);
                break;
        }
        
        if (contador >= 25)
        {
           //moneda5_cambio.SetActive(true);
        }
    }

    private void OnTriggerStay(Collider other)
    {
       // Debug.Log("sigo colisionando"+other.gameObject.name);
    }
}
