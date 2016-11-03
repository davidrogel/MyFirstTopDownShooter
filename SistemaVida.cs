using UnityEngine;
using System.Collections;

public class SistemaVida : MonoBehaviour {

    /// <summary>
    /// vida inicial de la entidad
    /// </summary>
    public int vidaInicial = 3;

    /// <summary>
    ///  vida que le queda a la entidad
    /// </summary>
    int vidaActual;
    	
	void Start () {
        vidaActual = vidaInicial; // inicializamos la vida actual
	}
	
    // Metodo para provocar danho
    public void Danho(int dmg) // se le pasa un valor
    {
        vidaActual -= dmg; // se le resta el daño generado a la vida actual
        if (vidaActual <= 0) // si tiene 0 o menos la entidad se destruye
        {
            Destroy(this.gameObject);
        }
    }    

    public int GetVidaActual() // retorna la vida actual
    {
        return vidaActual;
    }
}
