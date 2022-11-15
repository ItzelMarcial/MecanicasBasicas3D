using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaRango : MonoBehaviour
{
    public int CantBalas = 10;
    public int MaxBalas = 20;
    public float TiempoEnfriamiento = 0.5f;
    //public float EfectoTiempo = 0.1f;

    int dmg = 15;
    public GameObject EfectoDisparo;
    //referencia a la camara 

   public Character Character;


    private Transform Camera;
    private float TiempoUltimoDisparo = 0;

    bool balaImpacto = false;
    

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
       
        LanzarRayo();
        
        
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

    void Start()
    {
        Camera = GameObject.FindGameObjectWithTag("MainCamera").transform;
        this.Character = GetComponent<Character>();
    }

    private void Update()
    {
        if (Time.time - TiempoUltimoDisparo < 0.3f)
        {
            EfectoDisparo.SetActive(false);
            
        }

        Debug.DrawRay(Camera.position, Camera.forward * 10f, Color.red);
        
       


    }

    private void LanzarRayo()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.position, Camera.forward, out hit, 70f))
        {
            
            Collider other = hit.collider;
            print(other.tag);
            if(other.tag == "Mob")
            {
                print("Colision con " + hit.transform.name);
                other.GetComponent<Character>().RecibirDanio(dmg, this.gameObject, hit.point);
            }
           
            
        }
        else
        {
            print("Ningún objeto golpeado");
        }
    }

    
}
