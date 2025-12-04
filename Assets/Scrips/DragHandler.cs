using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragHandler : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private Vector3 offset;
    private Camera camera_expendedora;  // Cámara para raycasting
    public Vector3 savedPosition; // Variable para guardar la posición
    private bool estaArrastrando = false;
    private RotateCoin rotateCoin;
    void Start()
    {
        DetectarCamara();
    }

    // Detecta cuando se comienza el arrastre
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Comenzó el arrastre");

        if (rotateCoin != null) 
        {
            rotateCoin.enabled = false; // Pausa la rotación
        }
        EmpezarArrastre(eventData);
    }

    // Detecta cuando se termina el arrastre
    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("Finalizó el arrastre");
        TerminarArrastre();
    }

    // Mientras se arrastra el objeto
    public void OnDrag(PointerEventData eventData)
    {
        if (estaArrastrando)
        {
            // Actualiza la posición del objeto
            transform.position = GetInputWorldPosition(eventData) + offset;
        }
    }
    
    private void EmpezarArrastre(PointerEventData eventData)
    {
        estaArrastrando = true;
        offset = transform.position - GetInputWorldPosition(eventData);
    }

    public void TerminarArrastre()
    {
        estaArrastrando = false; 
        transform.position = savedPosition;
        Debug.Log("Posición restaurada: " + savedPosition);
        rotateCoin.enabled = true;
    }

    private void MonedaInsertada()
    {

    }

    private Vector3 GetInputWorldPosition(PointerEventData eventData)
    {
        // Convertir la posición del input (mouse o toque) a posición en el mundo 2D
        Vector3 inputScreenPosition = eventData.position;
        inputScreenPosition.z = camera_expendedora.WorldToScreenPoint(transform.position).z;
        return camera_expendedora.ScreenToWorldPoint(inputScreenPosition);
    }
    public void DetectarCamara()
    {
        savedPosition = transform.position;
        camera_expendedora = GameObject.FindWithTag("camera_expendedora").GetComponent<Camera>();
        rotateCoin = GetComponent<RotateCoin>();
        Debug.Log("Cámara activa: " + camera_expendedora.name);
    }
}
