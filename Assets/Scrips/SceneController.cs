using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    // Tiempo de espera antes de cargar la siguiente escena (en segundos)
    private float tiempoDeEspera = 4f;
    public string nombreEscenaDestino;


    void Start()
    {
        // Iniciar la corrutina para esperar y luego cargar la siguiente escena
        StartCoroutine(EsperarYCargarEscena());
    }
    
    IEnumerator EsperarYCargarEscena()
    {
        // Esperar el tiempo definido
        yield return new WaitForSeconds(tiempoDeEspera);

        // Cargar la siguiente escena
        SceneManager.LoadScene(1);
    }

    public void CargarEscenaAlClick()
    {
        SceneManager.LoadScene(nombreEscenaDestino);
    }

  
 
}