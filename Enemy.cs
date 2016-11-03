using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    /// <summary>
    /// danho del enemigo
    /// </summary>
    public int danho = 1;

    /// <summary>
    ///  objetivo
    /// </summary>
    Transform target;
    /// <summary>
    /// referencia al NavMeshAgent
    /// </summary>
    NavMeshAgent agenteSmith;
    
	void Start () {
        agenteSmith = GetComponent<NavMeshAgent>(); // acedemos a su componente NavMeshAgent
        target = GameObject.FindGameObjectWithTag("Player").transform; // el objetivo lo buscamos por su TAG
    }	
	
	void Update () {

        if (target != null && target.gameObject.activeSelf) // si el objetivo no es nulo
        {
            agenteSmith.destination = target.position; // el agente lo sigue
        }
        else
        {
            agenteSmith.speed = 0f;  // si no, el agente se para
        }        
    }   
    
    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Player") // si cocha contra el jugador
        {
            col.gameObject.GetComponent<SistemaVida>().Danho(danho); // le hace danho
        }
    } 
}
