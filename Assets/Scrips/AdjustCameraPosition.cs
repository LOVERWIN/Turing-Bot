using UnityEngine;
using System.Collections;
public class AdjustCameraPosition : MonoBehaviour
{
    private new Camera camera;
    private Vector3 originalPosition;
    public static bool activaAnimacionCamera = false;
    void Start()
    {
        // Busca la cámara con el tag "cámaraEspendedora"
        GameObject camaraObj = GameObject.FindGameObjectWithTag("camera_expendedora");
        

        if (camaraObj != null)
        {
             camera = camaraObj.GetComponent<Camera>();

            if (camera != null)
            {
                originalPosition = camera.transform.position;
                // Relación de aspecto objetivo (16:9)
                float targetAspect = 16.0f / 9.0f;
                float windowAspect = (float)Screen.width / Screen.height;

                // Ajustar el FOV para pantallas más anchas o altas
                if (windowAspect < targetAspect) // Pantallas más altas
                {
                    float newFOV = camera.fieldOfView * (targetAspect / windowAspect);
                    camera.fieldOfView = Mathf.Clamp(newFOV, 72, 61); // Limitar el FOV a un rango aceptable
                    Debug.Log("entro if");
                }
            }
            else
            {
                Debug.LogError("El objeto con tag 'cámaraEspendedora' no tiene un componente Camera.");
            }
        }
        else
        {
            Debug.LogError("No se encontró ningún objeto con el tag 'cámaraEspendedora'.");
        }

    }
    public void MoveCamera()
    {
        if (camera != null)
        {
            Vector3 targetPosition = new Vector3(-3.96f, 1.42f, -4.77f);
            StartCoroutine(SmoothMove(targetPosition, 2.0f)); // Duración del movimiento
        }
        else
        {
            Debug.LogError("No hay una cámara asignada para mover.");
        }
    }

    private IEnumerator SmoothMove(Vector3 targetPosition, float duration)
    {
        float elapsedTime = 0;
        Vector3 startPosition = originalPosition;
        activaAnimacionCamera = true;
        while (elapsedTime < duration)
        {
            camera.transform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null; // Espera al siguiente frame
        }

        camera.transform.position = targetPosition; // Asegura que termine en la posición exacta
        Debug.Log("Cámara movida suavemente a nueva posición");
        activaAnimacionCamera = false;
    }
    public void RestaurarPosicionCamera()
    {
        if (camera != null)
        {
            camera.transform.position = originalPosition;
            Debug.Log("Cámara restaurada a su posición original");
        }
        else
        {
            Debug.LogError("No hay una cámara asignada para restaurar.");
        }
    }
}
