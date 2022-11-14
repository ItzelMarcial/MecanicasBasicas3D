using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaRango : MonoBehaviour
{
    public int CantBalas = 10;
    public int MaxBalas = 20;
    public float TiempoEnfriamiento = 0.5f;
    //public float EfectoTiempo = 0.1f;

    public GameObject EfectoDisparo;
    //referencia a la camara 
    
    public Transform LaCamara;
    private float TiempoUltimoDisparo = 0;

    bool balaImpacto = false;
    RaycastHit hit;

    public bool Disparar()
    {
        if (CantBalas <= 0) //no hay balas jsjsj
        {
            //no puedes disparar 
            print("Arma sin balas");
            return false;
        }

        if (Time.time - TiempoUltimoDisparo < TiempoEnfriamiento) //arma caliente
        {
            //no puedes disparar 
            return false;
        }
        //tarea aqui
        if (Physics.Raycast(LaCamara.transform.position
          + transform.forward * 1f, Vector3.forward, out hit, 70f))
        {
            Debug.DrawRay(LaCamara.transform.position, Vector3.forward * 70f, Color.blue);
            string nombre = hit.collider.gameObject.name;
            print("Golpe detectado");
            print("El objeto golpeado es" + name);

        }
        else
        {
            Debug.DrawRay(LaCamara.transform.position, Vector3.forward * 70f, Color.red);
        }
        //LanzarRayo();
        
        
        //Disparar efectivamente 
        CantBalas--;
        TiempoUltimoDisparo = Time.time;
        EfectoDisparo.SetActive(true);
        print("Bang!");
        return true;
    }

    public void Recargar()
    {

    }

    private void Update()
    {
        if (Time.time - TiempoUltimoDisparo < 0.3f)
        {
            EfectoDisparo.SetActive(false);
            
        }

     
        
           
        
        

        
       
           
       
        
    }

    private void LanzarRayo()
    {
        /*int layerMask = 0 << 7;
         RaycastHit hit;
        balaImpacto = Physics.Raycast(LaCamara.transform.position, Vector3.forward, out hit, 70f, 7);
        if (balaImpacto == true)
        {
            string nombre = hit.collider.gameObject.name;
            print("Golpe detectado");
            print("El objeto golpeado es" + name);
        }
        else
        {
            print("Sin golpe detectado");
        }*/
    }

    /*void OnDrawGizmos()
    {
        //Dibuja un rayo en el vector de enfrente del objeto
        //azul es true y rojo es false uwu
        Gizmos.color = balaImpacto ? Color.blue : Color.red;
        Gizmos.DrawLine(LaCamara.transform.position, //pivote
            Vector3.forward //Vector de enfrente
            * 70f); //Distancia del rayo, hay que parametrizar



    }*/
}
