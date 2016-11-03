using UnityEngine;
using System.Collections;

public class KeyController : MonoBehaviour {

    /// <summary>
    /// la posicion en el jugador de la llave
    /// </summary>
    public Transform keyPos;
    /// <summary>
    ///  prefab de la llave
    /// </summary>
    public GameObject key;

    /// <summary>
    /// la llave equipada
    /// </summary>
    GameObject keyEquipada;
    /// <summary>
    /// si el jugador tiene una llave
    /// </summary>
    bool tieneLlave;
    
	void Start () {
        tieneLlave = false; // iniciamos el bool a false porque no tiene llave en un principio
    }

    void OnTriggerEnter(Collider col)
    {
        // si el jugador entra en contacto con la llave y no tiene otra llave encima
        if(col.gameObject.tag == "Key" && !tieneLlave)
        {            
            tieneLlave = true; // tiene una llave
            Destroy(col.gameObject); // destruyes la llave que habia en el suelo
            // añades a la variable de llave equipada la Instancia de la llave
            keyEquipada = Instantiate(key, keyPos.position, keyPos.rotation) as GameObject;
            keyEquipada.transform.parent = keyPos; // emparentas la llave que te acabas de equipar con la posicion de la llave en el jugador
        }

        // si el jugador toca una puerta y lleva una llave 
        if(col.gameObject.tag == "Puerta" && tieneLlave)
        {            
            col.gameObject.SetActive(false); // desactivas la puerta
            Destroy(keyEquipada); // destruyes la llave equipada
            tieneLlave = false; // ya no tienes llave
        }
    }    
}
