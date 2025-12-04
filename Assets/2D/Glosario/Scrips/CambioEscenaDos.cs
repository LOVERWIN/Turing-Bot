using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarEscenaDos : MonoBehaviour
{
    public void CambiarAEscenaDos(string nombreEscena)
    {
        SceneManager.LoadScene(nombreEscena);
    }
}
