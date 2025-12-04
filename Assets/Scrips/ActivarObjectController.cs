using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarObjectController : MonoBehaviour
{
    [SerializeField] private GameObject moneda10;
    [SerializeField] private GameObject moneda5;
    private Vector3 moneda10PosInicial;
    private Vector3 moneda5PosInicial;
    void Start()
    {
        // Guardar la posición inicial de cada moneda
        moneda10PosInicial = moneda10.transform.position;
        moneda5PosInicial = moneda5.transform.position;
    }

    public void ReactivarObjetos()
    {
        moneda5.SetActive(true);
        moneda10.SetActive(true);
    }
    public void DesactivarObjetos()
    {
        moneda5.SetActive(false);
        moneda10.SetActive(false);
    }
    public void RestablecerMonedas()
    {
        
        
    }

    public void RestablecerCoin5()
    {
        moneda5.SetActive(false);
        moneda5.transform.position = moneda5PosInicial;
        moneda5.SetActive(true);
    }

    public void RestablecerCoin10()
    {
        moneda10.SetActive(false);
        moneda10.transform.position = moneda10PosInicial;
        moneda10.SetActive(true);
    }
}
