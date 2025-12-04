using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorBotellaPController : MonoBehaviour
{
    private Dictionary<Collider, float> triggerEnterTimes = new Dictionary<Collider, float>();
    private float requiredTimeInTrigger = 3f; // 3 segundos
    // Este método se llama cuando otro objeto entra en el Trigger
    void OnTriggerEnter(Collider other)
    {
        // Registra el momento en que el objeto entró al trigger
        if (!triggerEnterTimes.ContainsKey(other))
        {
            triggerEnterTimes.Add(other, Time.time);
        }
        RestaurarBotella(other);
        
    }

    // Este método se llama mientras otro objeto permanece en el Trigger
    void OnTriggerStay(Collider other)
    {
        // Verifica si el objeto lleva más de 3 segundos en el trigger
        if (triggerEnterTimes.TryGetValue(other, out float enterTime))
        {
            if (Time.time - enterTime >= requiredTimeInTrigger)
            {
                Debug.Log(other.gameObject.name + " ha estado 3 segundos en el trigger");
                Destroy(other.gameObject);
                //RestaurarBotella(other); // Llama a tu método
                //triggerEnterTimes.Remove(other); // Opcional: Evita repetir la acción
            }
        }
    }

    // Este método se llama cuando otro objeto sale del Trigger
    void OnTriggerExit(Collider other)
    {
        //Debug.Log("Elemento salió del Trigger: " + other.gameObject.name);
        // Opcional: Agregar lógica cuando el objeto sale del Trigger.
    }

    void RestaurarBotella(Collider other)
    {
        // Imprime el nombre del objeto que ha activado el Trigger
        //Debug.Log("Elemento que entró al Trigger: " + other.gameObject.name);

        // Obtén el GameObject que activó el Trigger
        GameObject objet = other.gameObject;

        // Nueva posición con Z aleatorio entre -6.849 y -3.218
        float randomZ = Random.Range(-2.569f, -3.218f);
        Vector3 nuevaPosicion = new Vector3(randomZ, 0.505f, -5.705976f); // x ahora es aleatorio

        objet.transform.rotation = Quaternion.Euler(90, 0, 0);
        objet.transform.position = nuevaPosicion;

        BoxCollider boxCollider = objet.GetComponent<BoxCollider>();
        if (boxCollider != null)
        {
            Vector3 customCenter = new Vector3(2.533197e-07f, 0.2450014f, -2.384186e-07f);
            Vector3 customSize = new Vector3(0.2036034f, 0.4899998f, 0.2140813f);
            boxCollider.center = customCenter;
            boxCollider.size = customSize;
            boxCollider.isTrigger = false;
        }
        else
        {
            Debug.LogWarning("El objeto colisionado no tiene un BoxCollider.");
        }
    }


}
