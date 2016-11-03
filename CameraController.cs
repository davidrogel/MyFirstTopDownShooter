using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    /// <summary>
    /// jugador
    /// </summary>
    public GameObject player;
    /// <summary>
    /// es el vector entre la posicion de la camara y el jugador
    /// </summary>
    private Vector3 offset;
    
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    void Update()
    {        
        if(player != null)
            // la posicion de la camara es la posicion del jugador mas la distancia entre los dos
            transform.position = player.transform.position + offset;
    }
}
