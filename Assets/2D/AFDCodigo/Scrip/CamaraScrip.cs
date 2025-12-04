using System.Collections;
using UnityEngine;

public class CameraSizeAdjust : MonoBehaviour
{
    public Camera mainCamera; // La cámara que vamos a modificar
    private float zoomSpeed = 4f; // Velocidad del cambio de tamaño
    private float initialSize = 630f; // Tamaño inicial de la cámara
    private float targetSize = 200f; // Tamaño deseado después del "zoom"
    private float delayBeforeZoom = 2f; // Retraso antes de cambiar el tamaño
    public GameObject home;
    private IEnumerator AdjustSize()
    {
        // Espera antes de iniciar el cambio
        yield return new WaitForSeconds(delayBeforeZoom);

        float timeElapsed = 0f;
        float startSize = mainCamera.orthographicSize;

        while (timeElapsed < zoomSpeed)
        {
            timeElapsed += Time.deltaTime;
            // Interpolación del tamaño ortográfico
            mainCamera.orthographicSize = Mathf.Lerp(startSize, targetSize, timeElapsed / zoomSpeed);
            yield return null; // Espera hasta el siguiente frame
        }

        // Asegúrate de que el tamaño final sea exactamente el deseado
        mainCamera.orthographicSize = targetSize;

        home.SetActive(true);
    }

    void Start()
    {
        // Asegúrate de que la cámara tenga el tamaño inicial
        mainCamera.orthographicSize = initialSize;

        // Inicia la corutina para ajustar el tamaño
        StartCoroutine(AdjustSize());
    }
}
