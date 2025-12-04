using System.Collections;
using UnityEngine;
using TMPro;

public class TextoControlador : MonoBehaviour
{
    //5public AudioSource audioSource; // Asignado en el Inspector al AudioSource del Canvas
    //public AudioClip[] audios; // Asignado en el Inspector con los audios
    /*
    public void ReproducirAudio(int indice)
    {

        Debug.Log("Cantidad de audios: " + audios.Length);
        Debug.Log("Índice recibido: " + indice);
        if (audioSource.isPlaying) // Evita superposición de audios
        {
            audioSource.Stop();
        }
        audioSource.clip = audios[indice];
        audioSource.Play();
        //Debug.Log("Reproduciendo: " + audioSource.clip.name);
    }
    /*
    public void SilenciarTodos()
    {
        audioSource.Stop(); // Detiene cualquier audio en reproducción
    }
    */

    public TextMeshProUGUI textoPrincipal; // Referencia al texto
    public GameObject nube; // Referencia al sprite de la nube
    public GameObject qAcept; // Referencia al sprite de la aceptacion
    public GameObject qEstados; // Referencia al sprite de los estados
    //public GameObject qAlfabeto; // Referencia al sprite del alfabeto
    public GameObject qInicial; // Referencia al sprite del estado inicial
    public GameObject qTransicion; // Referencia al sprite de transicion
    public GameObject Monedas;

    private Coroutine escrituraCoroutine;
    private float tiempo = 0.07f;

    // Metodo para ocultar todos los elementos interactivos

    public void Ocultar()
    {
        qAcept.SetActive(false);
        Monedas.SetActive(false);
        qEstados.SetActive(false);
        qInicial.SetActive(false);
        qTransicion.SetActive(false);
    }



    // Método para iniciar la escritura progresiva
    public void EscribirTexto(string nuevoTexto, float velocidad)
    {
        Ocultar();
        // Si ya hay una corutina activa, la detiene
        if (escrituraCoroutine != null)
        {
            StopCoroutine(escrituraCoroutine);
        }

        // Activa la nube con animación antes de escribir
        StartCoroutine(AparecerNube());

        // Inicia una nueva corutina para el efecto de escritura
        escrituraCoroutine = StartCoroutine(EfectoEscritura(nuevoTexto, velocidad));
    }

    // Corutina que genera el efecto de escritura
    private IEnumerator EfectoEscritura(string nuevoTexto, float velocidad)
    {
        textoPrincipal.text = ""; // Limpia el texto actual

        foreach (char letra in nuevoTexto)
        {
            textoPrincipal.text += letra; // Añade letra por letra
            yield return new WaitForSeconds(velocidad); // Espera un momento antes de la siguiente letra
        }

        // Espera unos segundos después de terminar el texto antes de ocultar la nube
        //yield return new WaitForSeconds(2f);
        //nube.SetActive(false);
    }

    // Animación de aparición de la nube
    private IEnumerator AparecerNube()
    {
        Vector3 escalaFinal = new Vector3(6f, 10f, 6f);

        nube.SetActive(true); // Asegúrate de activar la nube
        nube.transform.localScale = Vector3.zero; // Comienza desde escala 0

        float duracion = 0.5f; // Duración de la animación
        float tiempo = 0;

        while (tiempo < duracion)
        {
            tiempo += Time.deltaTime;
            float progreso = tiempo / duracion; // Progreso de la animación entre 0 y 1
            nube.transform.localScale = Vector3.Lerp(Vector3.zero, escalaFinal, progreso); // Interpola hacia la escala final
            yield return null;
        }

        nube.transform.localScale = escalaFinal; // Asegúrate de dejarla en su tamaño final
    }


    // Métodos de prueba para los botones
    public void CambiarEstado()
    {
        EscribirTexto("Un estado representa una situación específica en la que la máquina procesa una secuencia de símbolos. Los estados determinan cómo responde el autómata a cada símbolo del alfabeto.", tiempo);
        qEstados.SetActive(true);
        //ReproducirAudio(0);

    }

    public void CambiarEntrada()
    {
        EscribirTexto("El alfabeto de entrada es un conjunto finito de símbolos procesables por la máquina. Cada símbolo desencadena una transición que mueve al autómata de su estado actual hacia otro.", tiempo);
        Monedas.SetActive(true);
        //ReproducirAudio(1);

    }

    public void CambiarInicial()
    {
        EscribirTexto("El estado inicial es donde la máquina comienza a procesar una cadena de símbolos. Es único dentro del autómata y crucial para determinar el recorrido según los símbolos recibidos.", tiempo);
        qInicial.SetActive(true);
        //ReproducirAudio(2);

    }

    public void CambiarAceptacion()
    {
        EscribirTexto("Un estado de aceptación indica que una cadena fue reconocida por el autómata. Si al procesar todos los símbolos el autómata termina en este estado, la cadena pertenece al lenguaje.", tiempo);
        qAcept.SetActive(true);
        //ReproducirAudio(3);

    }

    public void CambiarTransicion()
    {
        EscribirTexto("Las transiciones en un Autómata Finito Determinista son reglas que definen cómo la máquina cambia de estado según el símbolo procesado, determinando su capacidad para reconocer patrones.", tiempo);
        qTransicion.SetActive(true);
        //ReproducirAudio(4);

    }
}

