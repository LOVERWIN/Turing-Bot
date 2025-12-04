using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RampaRotarRefresco : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // Rota el objeto que colisionó 60 grados en X
        collision.transform.Rotate(60f, 0f, 0f);
    }
}
