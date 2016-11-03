using UnityEngine;
using System.Collections;

public class TextVida : MonoBehaviour {

    /// <summary>
    /// prefab del jugador
    /// </summary>
    public GameObject jugador;

    /// <summary>
    /// referencia al TextMesh
    /// </summary>
    TextMesh text;    
	
	void Start () {
        text = GetComponent<TextMesh>(); // obtienes el componenete 
	}
	
	void Update () {
        if(jugador != null) // si el jugador no es nulo
            // coges la vida actual del jugador y la muestras en el TextMesh
            text.text = jugador.GetComponent<SistemaVida>().GetVidaActual().ToString();
	}
}
