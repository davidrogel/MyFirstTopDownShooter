using UnityEngine;
using System.Collections;

public class PackController : MonoBehaviour {

    /// <summary>
    ///  espalda del jugador
    /// </summary>
    public Transform back;
    /// <summary>
    ///  paquete
    /// </summary>
    public GameObject pack;
    /// <summary>
    ///  script que controla el drop del paquete
    /// </summary>
    public DropController drop;

    /// <summary>
    /// ¿tienes algo en la espalda?
    /// </summary>
    bool enLaEspalda;

    void Start () {
        enLaEspalda = false; // se inicializa el bool a false porque no tienes nada a la espalda
    }	
	
    void OnTriggerEnter(Collider col)
    {
        // si colisionas contra el paquete y no tienes nada a la espalda
        if (col.gameObject.tag == "Pack" && !enLaEspalda)
        {
            enLaEspalda = true; // tienes algo a la espalda
            Destroy(col.gameObject);
            GameObject package = Instantiate(pack, back.position, back.rotation) as GameObject; // te pones el paquete a la espalda
            package.GetComponent<Platform>().enabled = false;  // desactivo su movimiento
            package.transform.parent = back; // se te parenta el paquete con la espalda
        }

        // si colisionas contra la plataforma
        if(col.gameObject.tag == "Platform")
        {
            // llamada metrodo SoltarCarga pasandole el Transform de la plataforma en la que tienes que dejar el paquete
            drop.SoltarCarga(col.gameObject.transform);
        }
    }

    public bool GetEnLaEspalda()
    {
        return enLaEspalda; // ¿ llevo algo o no ? 
    }

    public void SetEnLaEspalda()
    {
        enLaEspalda = false; // ya no llevo nada
    }
}
