using UnityEngine;
using System.Collections;

public class DropController : MonoBehaviour {

    /// <summary>
    /// donde se coloca el paquete
    /// </summary>
    public Transform[] pedestal;
    /// <summary>
    /// script que controla el paquete
    /// </summary>
    public PackController packController;
    
    // metodo que deposita la carga en la plataforma que le pasas
    public void SoltarCarga(Transform plataforma)
    {
        //recorro cada uno de los pedestales
        foreach(Transform pie in pedestal)
        {
            // si llevas algo a la espalda Y el pedestal no tiene nada
            if (packController.GetEnLaEspalda() && pie.childCount == 0)
            {
                //el paquete
                Transform packageChild = transform.GetChild(0);
                //el paquete se pone el la posicion del pedestal que es hijo de la plataforma X                
                packageChild.transform.position = plataforma.GetChild(0).transform.position;
                //el paquete se emparenta con el pedestal
                packageChild.transform.parent = plataforma.GetChild(0).transform;
                //enviamos el mensage de que no tiene nada a la espalda
                packController.SetEnLaEspalda();
            }
        }           
    }
}
