using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    /// <summary>
    /// velocidad de la bala
    /// </summary>
    public float bulletSpeed = 35;
    /// <summary>
    /// danho de la bala
    /// </summary>
    public int danho = 1; 
    /// <summary>
    /// radio de accion de la bala
    /// </summary>
    public float radio = 0.1f;
    /// <summary>
    /// tiempo de vida de la bala
    /// </summary>
    public float liveTime = 3;    
	
	void Start () {
        Destroy(gameObject, liveTime);// destruye la bala cuando pasa su tiempo de vida        
	}	
	
	void Update () {
        // la bala se mueve hacia delante
        transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime); 
        ComprobarHit();// comprobamos si choca contra algo
    }

    void ComprobarHit()
    {
        /*  miramos las colisiones con OverlapSphere que devuelve un array de los 
            Collaiders que hay dentro de una esfera de X de radio */
        Collider[] col = Physics.OverlapSphere(transform.position, radio);
        // para cada Collider en el array 
        foreach (Collider coll in col)
        {
            // si el gameObject de algun collider es el del enemigo
            if(coll.gameObject.layer == 9) // layer 9 = enemigo
            {
                coll.gameObject.GetComponent<SistemaVida>().Danho(danho); // toma su sistema de vida y le hace danho
                DestroyImmediate(this.gameObject); // y destruye la bala 
            }

            // si el gameObject de algun collider es el de un muro
            if (coll.gameObject.layer == 10 && coll.gameObject != null) // layer 10 = muros
            {
                DestroyImmediate(this.gameObject); // destruye la bala para que no lo atraviese
            }
            
        }
    }    
}
