using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CuboBasura : MonoBehaviour
{
    private AudioSource audioSource;
    private void Start()
    {

        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.clip = Resources.Load<AudioClip>("sonidos/TirarBotellaBasura");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Rota el objeto que colisionó 60 grados en X
        if (collision.gameObject.tag == "Coin_10" || collision.gameObject.tag == "Coin_5")
        {
            Debug.Log("No eliminar las monedas");
        }
        else
        {
            Destroy(collision.gameObject);
            audioSource.Play();
        }
    }
        
}
