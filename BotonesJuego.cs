using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BotonesJuego : MonoBehaviour {

	public void VolverAJugar()
    {
        SceneManager.LoadScene("main"); // cargas la escena de juego
    }

    public void VolverAInicio()
    {
        SceneManager.LoadScene("Inicio"); // cargas la escena de inicio
    }
}
