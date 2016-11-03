using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
    /// <summary>
    /// referencia al jugador
    /// </summary>
    public GameObject player;
    /// <summary>
    /// array de pedestales
    /// </summary>
    public Transform[] pedestal;

    /// <summary>
    /// pantalla de has ganado
    /// </summary>
    public GameObject hasGanado;
    /// <summary>
    /// pantalla de has perdido
    /// </summary>
    public GameObject hasPerdido;
    
	void Update () {
	    
        if (pedestal[0].childCount == 1 && pedestal[1].childCount == 1) // si los dos pedestales estan ocupados
        {
            player.SetActive(false); // se destruye el jugador para que se paren los enemigos y los spawners
            hasGanado.SetActive(true); // sale la pantalla de has ganado
        }

        if (player == null) // si el jugador es nulo
        {
            hasPerdido.SetActive(true); // se activa la pantalla de has perdido
        }


        //for (int i = 0; i < pedestal.Length; i++)
        //{
        //    if (pedestal[i].childCount == 1)
        //    {
        //        Destroy(player);
        //        hasGanado.SetActive(true);
        //    }
        //}
    }
}
