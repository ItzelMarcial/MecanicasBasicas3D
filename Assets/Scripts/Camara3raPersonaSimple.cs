using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara3raPersonaSimple : MonoBehaviour
{

    public Transform Objetivo;
    public float AumentaForward = 1f;
    public float AumentaUp = 1f;

    public float AumentaPiso = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(Objetivo != null)
        {
            //Genera una posicion màs estable para que la camara lo siga
            Vector3 posObjetivo = new Vector3(
                Objetivo.position.x,
                Objetivo.position.y + AumentaPiso,
                Objetivo.position.z);

            Vector3 posTrasera = 
                posObjetivo
                - Objetivo.forward * AumentaForward
                +Vector3.up * AumentaUp;

            //La camara va a estar atras del objetivo

            this.transform.position = posTrasera;

            //apunta la camara al objetivo
            this.transform.LookAt(posObjetivo);
        }

             
    }
}
