using UnityEngine;
using System.Collections.Generic;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class BotellaController : MonoBehaviour
{
    public List<GameObject> prefabs; // Lista de prefabs configurada desde el Inspector
    public List<Vector3> posicionesIniciales; // Lista de posiciones iniciales configurada desde el Inspector
    public int cantidad = 4; // N�mero de objetos a crear por prefab
    public float separacion; // Separaci�n entre objetos en el eje Z
    private Queue<GameObject> objetosEnColision = new Queue<GameObject>(); // Cola para manejar los objetos en colisi�n
    void Start()
    {
        CrearArreglosConPosiciones();
       
    }

    public void CrearArreglosConPosiciones()
    {
        // for (int i = 0; i < posicionesIniciales.Count; i++)
        // {
        //     Debug.Log($"Posición inicial [{i}]: {posicionesIniciales[i]}");
        // }

        // Verifica que ambas listas tengan el mismo tama�o
        if (prefabs.Count != posicionesIniciales.Count)
        {
            Debug.LogError("La cantidad de prefabs y posiciones iniciales no coincide.");
            return;
        }

        // Recorre cada prefab y su posici�n inicial correspondiente
        for (int i = 0; i < prefabs.Count; i++)
        {
            GameObject prefabActual = prefabs[i];
            Vector3 posicionInicial = posicionesIniciales[i];

            for (int j = 0; j < cantidad; j++)
            {
                // Calcula la posici�n para el objeto actual
                Vector3 posicion = posicionInicial + new Vector3(0, 0, j * separacion);
                //Debug.Log($"Instanciando {prefabActual.name} en posición: {posicion}");


                // Instancia el prefab en la posici�n calculada
                GameObject nuevoObjeto = Instantiate(prefabActual, posicion, Quaternion.identity);

                // Asigna un nombre con un sufijo auto-incremental
                nuevoObjeto.name = prefabActual.name + "_" + (j+1);

                // Agrega un BoxCollider si no tiene uno
                if (nuevoObjeto.GetComponent<BoxCollider>() == null)
                {
                    BoxCollider boxCollider = nuevoObjeto.AddComponent<BoxCollider>();
                    XRGrabInteractable interactable = nuevoObjeto.AddComponent<XRGrabInteractable>();
                    // Configurar el centro del collider
                    boxCollider.center = new Vector3(2.53324e-07f, 0.2450014f, 0.05413324f);
                    boxCollider.size = new Vector3(0.2036037f, 0.4900003f,0.1058146f); // Ancho: 1.5, Alto: 2.0, Profundidad: 1.0
                    //nuevoObjeto.AddComponent<Rigidbody>();
                }
            }
        }
    }

    void OnCollisionStay(Collision collision)
    {
        // Si el objeto no est� ya en la cola, lo agregamos
        if (!objetosEnColision.Contains(collision.gameObject))
        {
            objetosEnColision.Enqueue(collision.gameObject); // Agregar el objeto a la cola
            Debug.Log($"Objeto agregado: {collision.gameObject.name}");
        }

        // Si hay 4 o m�s objetos en la cola, eliminamos el primero que entr�
        if (objetosEnColision.Count > 1)
        {
            GameObject objetoAEliminar = objetosEnColision.Dequeue(); // Sacar el primer objeto de la cola
            Debug.Log($"Eliminando objeto: {objetoAEliminar.name}");
            Destroy(objetoAEliminar); // Destruir el objeto
        }
    }

    void OnCollisionExit(Collision collision)
    {
        // Cuando un objeto deja de estar en colisi�n, lo removemos de la cola si est� presente
        if (objetosEnColision.Contains(collision.gameObject))
        {
            objetosEnColision = new Queue<GameObject>(objetosEnColision); // Reconstruir la cola sin el objeto
            Debug.Log($"Objeto sali� de la colisi�n: {collision.gameObject.name}");
        }
    }
}
