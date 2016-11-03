using UnityEngine;
using System.Collections;

// Le obligamos a que tenga un Rigidbody con RequireComponent
[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour {

    /// <summary>
    /// velocidad de movimiento
    /// </summary>
    public float walkSpeed = 5;
    
    /// <summary>
    /// referencia al Rigidbody
    /// </summary>
    Rigidbody rb;
    /// <summary>
    /// referencia a la Camara
    /// </summary>
    Camera cam;

	void Start () {        
        rb = GetComponent<Rigidbody>(); // obtenemos el componente de Rigidbody
        cam = Camera.main; // obtenemos la camara principal
	}
		
	void Update () {
        Rotate();        
    }

    void FixedUpdate()
    {
        Mov();
    }

    // movimiento del personaje 
    void Mov()
    {
        // direccion hacia la que se mueve el personaje mediante las teclas  
        // el vector esta normalizado para que no corra mas en diagonal
        Vector3 dir = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical")).normalized;
        if(dir != Vector3.zero) // si el jugador se mueve
        {
            // multiplicamos la direccion por la velocidad
            Vector3 movement = dir * walkSpeed * Time.fixedDeltaTime; 
            rb.MovePosition(rb.position + movement); // sumamos la posicion del Rigidbody al movimiento
        }

        if (Input.GetKey(KeyCode.LeftShift)) // si se pulsa la tecla shift se corre
            walkSpeed = 10;
        else // si no se anda
            walkSpeed = 5;
        
    }

    // rotacion del personaje
    void Rotate()
    {
        // posicion del raton 
        Vector3 mousePos = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, cam.transform.position.y - transform.position.y));
        // el jugador mira hacia donde esta el raton
        Vector3 lookDirection = new Vector3(mousePos.x, transform.position.y, mousePos.z);
        transform.LookAt(lookDirection);
    }     
}
