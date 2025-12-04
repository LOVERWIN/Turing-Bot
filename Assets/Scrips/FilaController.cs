using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class FilaController : MonoBehaviour
{



    private float distanciaMovimiento = 0.2f; // Distancia que quieres mover en el eje Z
    private float duracionMovimiento = 1f; // Tiempo que tomar� completar el movimiento
    private int animacionesActivas = 0;
    public static bool activaAnimacion = false;

    public int contadorBotellas;
    private List<Vector3> posicionesGuardadas; // Lista para guardar posiciones din�micamente
    private GameObject TipoDeBotella; // Variable para guardar el primer prefab detectado
    private List<GameObject> botellasDentroDelTrigger = new List<GameObject>();
    private AudioSource audioSource;
    void Start()
    {
        posicionesGuardadas = new List<Vector3>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }


    void OnTriggerEnter(Collider other)
    {
        ObtenerRutaPrefab(other);
        ObtenerPosicionesBotellas(other);
        

        // Si no est� en la lista, agregarla
        if (!botellasDentroDelTrigger.Contains(other.gameObject))
        {
            botellasDentroDelTrigger.Add(other.gameObject);
            contadorBotellas += 1;
        }

        if (contadorBotellas >= 4)
        {
           // DespacharBotella();
        }

    }

    void OnTriggerExit(Collider other)
    {

        //Debug.Log("Perdido: "+ other.gameObject.name);
        contadorBotellas -= 1;
        botellasDentroDelTrigger.Remove(other.gameObject);
        if (contadorBotellas <= 0)
        {
            Debug.Log("Se acabaron las botellas");
            RellenarBotellas();
        }
       
    }


    void ObtenerPosicionesBotellas(Collider other)
    {
        // Solo guarda la posici�n si hay menos de 4 posiciones guardadas
        if (posicionesGuardadas.Count < 4)
        {
            Vector3 posicionObjeto = other.transform.position;

            // Agrega la posici�n a la lista
            posicionesGuardadas.Add(posicionObjeto);

            // Descomenta esta l�nea para ver el log de las posiciones guardadas en la consola
            //Debug.Log("Posici�n guardada: " + posicionObjeto);
        }
        else
        {
            //Debug.Log("Ya se han guardado 4 posiciones. No se agregar�n m�s.");
        }

    }

    void RellenarBotellas()
    {
        posicionesGuardadas.Sort((a, b) => a.z.CompareTo(b.z));
        // Recorre la lista de posiciones guardadas
        int num = 0;
        foreach (Vector3 posicion in posicionesGuardadas)
        {
            // Instancia el prefab en la posici�n dada
            GameObject objetoCreado = Instantiate(TipoDeBotella, posicion, Quaternion.identity);
           
            // Asigna un nombre �nico al objeto creado (puedes personalizarlo)
            objetoCreado.name = TipoDeBotella.name + "_" + (++num);
            // Agrega un BoxCollider si no tiene uno
            if (objetoCreado.GetComponent<BoxCollider>() == null)
            {
                BoxCollider boxCollider = objetoCreado.AddComponent<BoxCollider>();
                // Configurar el centro del collider
                boxCollider.center = new Vector3(2.53324e-07f, 0.2450014f, 0.05413324f);
                boxCollider.size = new Vector3(0.2036037f, 0.4900003f, 0.1058146f); // Ancho: 1.5, Alto: 2.0, Profundidad: 1.0
                objetoCreado.AddComponent<Rigidbody>();
            }
        }
    }
    
    void ObtenerRutaPrefab(Collider other)
    {
        if (TipoDeBotella == null)
        {
            string nombreCompleto = other.gameObject.name;
            if (nombreCompleto.Contains("_"))
            {
                string nombreBase = nombreCompleto.Split('_')[0];
                //Debug.Log("Nombre base detectado: " + nombreBase);

           
                //Debug.Log("Primer prefab detectado con nombre base: " + nombreBase);
                // Cargar el prefab din�micamente desde Resources usando el nombre base
                TipoDeBotella = Resources.Load<GameObject>("Botellas/Prefab/" + nombreBase);
            }
            else
            {
            Debug.LogWarning("El objeto no sigue el patr�n esperado: " + nombreCompleto);
            }
        }

    }

    public void DespacharBotella()
    {
        animacionesActivas = botellasDentroDelTrigger.Count; // Total de botellas
        audioSource.clip = Resources.Load<AudioClip>("sonidos/Refrescodespachado");
        audioSource.pitch = 0.6f;
        audioSource.Play();
        foreach (GameObject botella in botellasDentroDelTrigger)
        {
            StartCoroutine(MoverBotellaGradualmente(botella, distanciaMovimiento, duracionMovimiento));
        }

        StartCoroutine(EsperarAnimaciones());
    }

    private IEnumerator MoverBotellaGradualmente(GameObject botella, float distancia, float duracion)
    {
        float tiempo = 0f;
        Vector3 posicionInicial = botella.transform.position;
        Vector3 posicionFinal = posicionInicial + Vector3.forward * distancia;

        while (tiempo < duracion)
        {
            tiempo += Time.deltaTime;
            botella.transform.position = Vector3.Lerp(posicionInicial, posicionFinal, tiempo / duracion);
            yield return null;
        }

        // Marca que esta animaci�n termin�
        animacionesActivas--;
    }

    private IEnumerator EsperarAnimaciones()
    {
        // Esperar hasta que todas las animaciones terminen
        while (animacionesActivas > 0)
        {
            yield return null;
            activaAnimacion = true;


        }
        activaAnimacion = false;

        // Aqu� puedes continuar con la siguiente l�gica
        Debug.Log("Todas las animaciones han terminado.");
    }


}
