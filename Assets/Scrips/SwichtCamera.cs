using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwichtCamera : MonoBehaviour
{
    public Camera[] cameras;

    

    private int currentCameraIndex = 0;


    void Start()
    {
        // Asegúrate de que solo la cámara y el canvas iniciales estén activos
        for (int i = 0; i < cameras.Length; i++)
        {
            cameras[i].gameObject.SetActive(i == currentCameraIndex);
        }

    }

    public void SwitchCamera(int index)
    {
        if (index >= 0 && index < cameras.Length)
        {
            if (index == 1)
            {
                cameras[currentCameraIndex].gameObject.SetActive(false);
                cameras[index].gameObject.SetActive(true);
                currentCameraIndex = index;
                return;
            }
            cameras[currentCameraIndex].gameObject.SetActive(false);
            cameras[index].gameObject.SetActive(true);
            currentCameraIndex = index;
        }
        else
        {
            Debug.LogWarning("Índice de cámara fuera de rango.");
        }
    }

   


}