using UnityEngine;

public class AutomataController : MonoBehaviour
{
    public Material[] materiales; // Array de materiales disponibles
    private Renderer[] estadosRenderers; // Renderers de los estados

    void Start()
    {
        // Obtener todos los Renderers de los hijos (Estados)
        estadosRenderers = GetComponentsInChildren<Renderer>();
    }

    // M�todo para cambiar el material de un estado espec�fico
    public void CambiarMaterial(string nombreEstado, int materialIndex)
    {
        if (materialIndex < 0 || materialIndex >= materiales.Length)
        {
            Debug.LogWarning("�ndice de material fuera de rango.");
            return;
        }

        // Buscar el estado por nombre dentro de los hijos
        Transform estado = transform.Find(nombreEstado);
        if (estado != null)
        {
            Renderer renderer = estado.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.material = materiales[materialIndex];
                Debug.Log("material Cambiado");
            }
            else
            {
                Debug.LogWarning("El estado no tiene un Renderer.");
            }
        }
        else
        {
            Debug.LogWarning("Estado no encontrado.");
        }
    }

    public void ResetearAutomata()
    {
        CambiarMaterial("q0_inicio_inactivo",2);
        CambiarMaterial("q2_inactivo", 7);
        CambiarMaterial("q3_inactivo", 9);
        CambiarMaterial("q1_inactivo", 5);
        CambiarMaterial("q4_aceptacion_inactivo", 11);
        CambiarMaterial("transicion_q0_q1", 1);
        CambiarMaterial("transicion_q0_q2", 1);
        CambiarMaterial("transicion_q1_q2", 1);
        CambiarMaterial("transicion_q1_q3", 1);
        CambiarMaterial("transicion_q2_q3", 1);
        CambiarMaterial("transicion_q2_q4", 1);
        CambiarMaterial("transicion_q3_q4", 1);

    }
}
