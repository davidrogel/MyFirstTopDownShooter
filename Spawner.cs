using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

    /// <summary>
    /// Prefab del enemigo
    /// </summary>
    public GameObject enemy;
    /// <summary>
    /// Prefab del jugador
    /// </summary>
    public GameObject player;
    /// <summary>
    /// Desde donde se spawnea el enemigo
    /// </summary>
    public Transform spawnPoint;
    /// <summary>
    /// tiempo entre el spawn de cada enemigo
    /// </summary>
    public float tiempoEntreSpawn;
    /// <summary>
    /// proximo spawn 
    /// </summary>
    float nextSpawnTime;
	
	void Update () {
        // se produce un spawn si el tiempo de juego es mayor que el nextSpawnTime 
        // y si el jugador no es nulo
        if (Time.time > nextSpawnTime && player != null && player.gameObject.activeSelf) 
        {
            nextSpawnTime = Time.time + tiempoEntreSpawn;                      
            Instantiate(enemy, spawnPoint.position, spawnPoint.rotation); // Instancia del enemigo
        }
    }
}
