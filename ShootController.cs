using UnityEngine;
using System.Collections;

public class ShootController : MonoBehaviour {

    /// <summary>
    /// tiempo entre cada bala o disparo;
    /// </summary>
    float tiempoEntreBala;
    /// <summary>
    /// cantidad de perdigones que salen de la escopeta
    /// </summary>
    public float numPerdigones = 5;
    /// <summary>
    /// angulacion con la que los perdigones se separan
    /// </summary>
    public float separacionEntrePerdigones = 0.01f;

    /// <summary>
    /// desde donde sale la bala
    /// </summary>
    public Transform salidaBala;
    /// <summary>
    /// prefab de la bala
    /// </summary>
    public GameObject bullet;
    /// <summary>
    /// posicion de la mano
    /// </summary>
    public Transform hand;

    /// <summary>
    /// que tipo de disparo está activo
    /// </summary>
    bool activoPistola;
    /// <summary>
    /// tiempo hasta proxima bala
    /// </summary>
    float proximaBala;    

    void Start()
    {
        activoPistola = true; // la pistola esta activa por defecto
    }

    void Update () {
        if (Input.GetKeyDown(KeyCode.Alpha1)) // si pulsas 1 se activa la pistola
            activoPistola = true;
        else if (Input.GetKeyDown(KeyCode.Alpha2)) // si pulsas 2 se activa la escopeta
            activoPistola = false;

        if (activoPistola)
            Shoot();
        else
            ShotGun();    
    }

    // disparo
    void Shoot()
    {
        tiempoEntreBala = 0.15f; // tiepo entre disparos para la pistola
        hand.GetChild(0).gameObject.SetActive(true); // activas la pistola
        hand.GetChild(1).gameObject.SetActive(false); // desactivas la escopeta

        // si pulsas click izquierdo y el tiempo de juego es mayor que la prosima bala, puedes disparar
        if (Input.GetMouseButton(0) && Time.time > proximaBala)
        {
            proximaBala = Time.time + tiempoEntreBala; // le sumas al la prixima bala el tiempo mas el tiempo entre balas
            Instantiate(bullet, salidaBala.position, salidaBala.rotation); // instancias la bala
        }

    }
    
    void ShotGun()
    {
        tiempoEntreBala = 1f;
        hand.GetChild(0).gameObject.SetActive(false); // desactivas la pistola
        hand.GetChild(1).gameObject.SetActive(true); // activas la escopeta

        if (Input.GetMouseButton(0) && Time.time > proximaBala)
        {
            for (int i = 0; i < numPerdigones; i++) // recorres la cantidad de balas que van a salir
            {
                // tomas la rotacion de la bala
                Quaternion rotPerdigon = bullet.gameObject.transform.rotation; 
                // para su X y su Y le das un angulo Random entre dos valores
                rotPerdigon.x += Random.Range(-separacionEntrePerdigones, separacionEntrePerdigones); 
                rotPerdigon.y += Random.Range(-separacionEntrePerdigones, separacionEntrePerdigones);
                Instantiate(bullet, salidaBala.position, salidaBala.rotation * rotPerdigon);// instancias la bala
            }
            proximaBala = Time.time + tiempoEntreBala;
        }
    }
}
