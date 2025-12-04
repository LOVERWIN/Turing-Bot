using UnityEngine;

public class CameraAdjustment : MonoBehaviour
{
    private Camera camera_expendedora; // Cámara que se ajustará
    private float defaultFOV = 126f;  // Valor por defecto para el FOV
    private Vector3 defaultPosition;  // Posición por defecto de la cámara

    // Valores para las posiciones y FOVs ajustados para diferentes orientaciones
    private float horizontalFOV = 59f;
    private Vector3 horizontalPosition = new Vector3(-4.347f, 1.564f, -2.444f);
    private Vector3 verticalPosition = new Vector3(-4.76f, 2.075f, -2.17f);

    void Start()
    {
        camera_expendedora = GameObject.FindWithTag("camera_expendedora").GetComponent<Camera>();
        defaultPosition = camera_expendedora.transform.position;
    }

    void Update()
    {
        // Detectar la orientación de la pantalla
        if (Screen.width < Screen.height) // Si está en orientación vertical
        {
            AdjustCameraForVertical();
        }
        else if (Screen.width > Screen.height) // Si está en orientación horizontal
        {
            AdjustCameraForHorizontal();
        }
    }


    // Ajuste de cámara para orientación vertical
    private void AdjustCameraForVertical()
    {
        camera_expendedora.fieldOfView = defaultFOV;  // FOV estándar
        camera_expendedora.transform.position = verticalPosition;  // Posición ajustada para vertical
        // Cambiar el campo de visión en el eje vertical si es necesario
        //camera_expendedora.fieldOfViewAxis = Camera.FieldOfViewAxis.Vertical;
    }

    // Ajuste de cámara para orientación horizontal
    private void AdjustCameraForHorizontal()
    {
        camera_expendedora.fieldOfView = horizontalFOV;  // FOV más amplio para horizontal
        camera_expendedora.transform.position = horizontalPosition;  // Posición ajustada para horizontal
        // Cambiar el campo de visión en el eje horizontal si es necesario
       // camera_expendedora.fieldOfViewAxis = Camera.FieldOfViewAxis.Horizontal;
    }
}
