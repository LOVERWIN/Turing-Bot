using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BotonesScrip : MonoBehaviour
{
    public GameObject[] estadosViejos;
    public GameObject[] estadoActual;
    public GameObject[] transiciones;
    public TextMeshProUGUI textoEstado;
    [SerializeField] private AudioSource audioSource;

    private Coroutine escrituraCoroutine;
    private int acumulador = 0;
    private int estado = 0;
    private float tiempo = 0.02f;

    private void Start()
    {
        EscribirTexto(
            "case 0: // q0\n\n" +
            "    if (moneda == 5) {\n \n" +
            "        estado = 1; // Transición a q1\n \n" +
            "    } else if (moneda == 10) {\n \n" +
            "        estado = 2; // Transición a q2\n \n" +
            "    }\n    break;", tiempo);
        
    }

    public void EscribirTexto(string nuevoTexto, float velocidad)
    {
        if (escrituraCoroutine != null)
            StopCoroutine(escrituraCoroutine);

        escrituraCoroutine = StartCoroutine(EfectoEscritura(nuevoTexto, velocidad));
    }

    private IEnumerator EfectoEscritura(string nuevoTexto, float velocidad)
    {
        textoEstado.text = "";
        foreach (char letra in nuevoTexto)
        {
            textoEstado.text += letra;
            yield return new WaitForSeconds(velocidad);
        }
    }

    public void Aumentar5() => AgregarMoneda(5);
    public void Aumentar10() => AgregarMoneda(10);

    private void AgregarMoneda(int valor)
    {
        if (acumulador < 25)
        {
            acumulador += valor;
            MostrarAcumulador();
            StartCoroutine(ProcesarMoneda());
        }
    }

    public void MostrarAcumulador()
    {
        Debug.Log("Acumulador: " + acumulador);
    }

    public void Despachar()
    {
        if (acumulador >= 20)
        {
            acumulador = 0;
            OcultarElementos();
            estado = 0;
            EscribirTexto(
                "case 0: // q0\n \n" +
                "    if (moneda == 5) {\n \n" +
                "        estado = 1;\n \n" +
                "    } else if (moneda == 10) {\n \n" +
                "        estado = 2;\n \n" +
                "    }\n    break;", tiempo);
        }
        ReproducirSonido("Estadoq0");
    }

    public void OcultarElementos()
    {
        foreach (GameObject estado in estadosViejos)
            if (estado != null) estado.SetActive(false);

        foreach (GameObject estado in estadoActual)
            if (estado != null) estado.SetActive(false);

        foreach (GameObject transicion in transiciones)
            if (transicion != null) transicion.SetActive(false);

        estadoActual[0].SetActive(true); // Reset visual al estado inicial
    }

    private void TransicionarEstado(int estadoAnterior, int nuevoEstado, int transicionIndex, string texto)
    {
        estadoActual[estadoAnterior].SetActive(false);
        estadosViejos[estadoAnterior].SetActive(true);
        estado = nuevoEstado;
        EscribirTexto(texto, tiempo);
        StartCoroutine(MostrarTransicion(transicionIndex, nuevoEstado));
    }

    private IEnumerator MostrarTransicion(int transicionIndex, int nuevoEstado)
    {
        yield return new WaitForSeconds(0.5f);
        transiciones[transicionIndex].SetActive(true);
        yield return new WaitForSeconds(0.5f);
        estadoActual[nuevoEstado].SetActive(true);
        //ReproducirSonido();
    }

    private void ReproducirSonido(string nombreSonido)
    {
        AudioClip clip = Resources.Load<AudioClip>("sonidos/"+nombreSonido);
        if (clip != null)
        {
            audioSource.clip = clip;
            audioSource.Play();
        }
        else
        {
            Debug.LogError("No se encontró el audio");
        }
    }

    public IEnumerator ProcesarMoneda()
    {
        switch (estado)
        {
            case 0:
                if (acumulador == 5)
                {
                    TransicionarEstado(0, 1, 0, "case 1: // q1\n \n    if (moneda == 5) {\n \n       estado = 2;\n \n    } else if (moneda == 10) {\n \n        estado = 3;\n \n   }\n \n    break;");
                    ReproducirSonido("Estadoq1");
                }
                else if (acumulador == 10)
                {
                    TransicionarEstado(0, 2, 1, "case 2: // q2\n \n    if (moneda == 5) {\n \n       estado = 3;\n \n    } else if (moneda == 10) {\n \n       estado = 4;\n \n    }\n \n    break;");
                    ReproducirSonido("Estadoq2");
                }
                break;

            case 1:
                if (acumulador == 10)
                {
                    TransicionarEstado(1, 2, 2, "case 2: // q2\n \n    if (moneda == 5) {\n \n       estado = 3;\n \n    } else if (moneda == 10) {\n \n        estado = 4;\n \n   }\n \n    break;");
                    ReproducirSonido("Estadoq2");
                }
                else if (acumulador == 15)
                {
                    TransicionarEstado(1, 3, 3, "case 3: // q3\n \n    if (moneda == 5 || moneda == 10) {\n \n       estado = 4;\n \n   }\n \n   break;");
                    ReproducirSonido("Estadoq3");
                }
                break;

            case 2:
                if (acumulador == 15)
                {
                    TransicionarEstado(2, 3, 4, "case 3: // q3\n \n    if (moneda == 5 || moneda == 10) {\n \n        estado = 4;\n \n    }\n \n   break;");
                    ReproducirSonido("Estadoq3");
                }
                else if (acumulador == 20)
                {
                    TransicionarEstado(2, 4, 5, "case 4: // q4 (aceptación)\n \n    break;");
                    ReproducirSonido("Estadoq4");
                }
                break;

            case 3:
                if (acumulador == 20 || acumulador == 25)
                {
                    TransicionarEstado(3, 4, 6, "case 4: // q4 (aceptación)\n \n    break;");
                    ReproducirSonido("Estadoq4");
                }
                break;

            case 4:
                // Estado final
                break;
        }

        yield return null;
    }
}
