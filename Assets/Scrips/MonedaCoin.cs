using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCoin : MonoBehaviour
{
    // Velocidad de rotaci�n (puedes ajustarla desde el Inspector)
    [SerializeField] private float rotationSpeed = 100f;
    private Vector3 posicionInicial;

    // Update se llama una vez por frame
    private void Start()
    {
        posicionInicial = transform.position;
    }

    void Update()
    {
        // Rota el objeto en su eje Y (u otro eje si lo necesitas)
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }

    public void RestablecerPosicion()
    {
        Debug.Log("Evento ejecutado desepues de soltar la moneda");
        if (transform.gameObject.activeSelf)
        {
            transform.position = posicionInicial;
            
        }
        
    }
    
}
