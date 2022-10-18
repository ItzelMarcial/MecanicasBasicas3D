using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    public Transform EfectoVisual;
    public abstract void Activar(Character perso);  

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {

            GetComponent<Collider>().enabled = false;
            Character perso
                = other.GetComponent<Character>();
            Recoger(perso);
        }
    }

    public void Recoger(Character perso)
    {
        print("Recogiendo item " + name);
        
        Activar(perso);

        Transform efecto = Instantiate(EfectoVisual, transform);
      
        
        
            Destroy(gameObject, 2);
        

            
        
        

    }

    
}
