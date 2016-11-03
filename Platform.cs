using UnityEngine;
using System.Collections;

public class Platform : MonoBehaviour {
    
    /// <summary>
    /// amplitud de la onda
    /// </summary>
    public float amplitud;
    /// <summary>
    /// velocidad con la que se mueve la plataforma
    /// </summary>
    public float speed = 1;

    /// <summary>
    /// posicion inicial de la plataforma
    /// </summary>
    Vector3 startPos;

    void Start () {
        startPos = transform.position; // inicializamos la posicion inicial de la plataforma
    }
		
	void Update () {        
        // se toma el valor Y de la posicion inicial
        float y = startPos.y;
        // se le suma la amplitud multiplicada por el Seno del tiempo por la velocidad
        y += amplitud * Mathf.Sin(Time.timeSinceLevelLoad * speed); 
        // se le pasa al objeto como se debe mover 
        transform.position = new Vector3(startPos.x, y, startPos.z);
    }
}
