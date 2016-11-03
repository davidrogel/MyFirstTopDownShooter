using UnityEngine;
using System.Collections;


public class LetsSeePlayer : MonoBehaviour {
       
    public float value = 0.2f;

    float distancia = 100f;
    MeshRenderer antiguoObjeto;
    
	void Update () {
        
        ComprobarSiAlgoEncima();
	}

    void ComprobarSiAlgoEncima()
    {   
        Ray ray = new Ray(transform.position, Vector3.up);
        Debug.DrawRay(transform.position, Vector3.up * distancia, Color.red);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, distancia))
        {
            if (hit.collider.gameObject.layer == 10 && hit.collider.gameObject.GetComponent<MeshRenderer>().material.color.a > .2f)
            {
                //StartCoroutine(FadeUt(hit));               
                FadeOut(hit);
            }

        }
        else if (antiguoObjeto.material.color.a < 1 && antiguoObjeto != null)
        {
            print("entras aqui ?");
            FadeIn();
            //StartCoroutine(FadeJin());
        }

    }

    void FadeOut(RaycastHit hit)
    {
        Color color = hit.collider.gameObject.GetComponent<MeshRenderer>().material.color;
        color.a -= value * Time.deltaTime;
        hit.collider.gameObject.GetComponent<MeshRenderer>().material.color = color;

        antiguoObjeto = hit.collider.gameObject.GetComponent<MeshRenderer>(); // ESTO FIX
    }

    //IEnumerator FadeUt(RaycastHit hit)
    //{
    //    Color color = hit.collider.gameObject.GetComponent<MeshRenderer>().material.color;
    //    color.a -= value * Time.deltaTime;
    //    hit.collider.gameObject.GetComponent<MeshRenderer>().material.color = color;

    //    antiguoObjeto = hit.collider.gameObject.GetComponent<MeshRenderer>();

    //    yield return new WaitForEndOfFrame();
    //}

    void FadeIn()
    {
        Color color = antiguoObjeto.material.color;
        color.a += value * Time.deltaTime;
        antiguoObjeto.material.color = color;

        //Color color = hit.collider.gameObject.GetComponent<MeshRenderer>().material.color;
        //color.a += value * Time.deltaTime;
        //hit.collider.gameObject.GetComponent<MeshRenderer>().material.color = color;
    }

    //IEnumerator FadeJin()
    //{
    //    Color color = antiguoObjeto.material.color;
    //    color.a += value * Time.deltaTime;
    //    antiguoObjeto.material.color = color;

    //    yield return new WaitForEndOfFrame();
    //}
}
