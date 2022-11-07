using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof (NavMeshAgent))] //De manera automatica agrega el NavMeshAgent
public class NPCCaminante : MonoBehaviour
{
    public NodoRuta Objetivo;
    //Si queremos que camine libremente hacia objetivos
    //Debe ser GameObject en lugar de NodoRuta

    public float DistMinObjetivo = 0.9f;
    private NavMeshAgent AgenteIA;

    void Start()
    {
        AgenteIA = GetComponent<NavMeshAgent>();
    }

    
    void Update()
    {
        //El destino al cual se dirige el IA, solo si no es nulo
        if(Objetivo != null)
        {
            

            float distAObjetivo = 
                (Objetivo.transform.position - transform.position).magnitude;
            //da la magnitud de la distancia
            //print("La distancia es " + distAObjetivo);

            if(distAObjetivo < DistMinObjetivo)
            {
                
                if(Random.value < 0.5f) //Random value da un numero entre 0 y 1
                {
                    Objetivo = Objetivo.NodoA;
                    
                }
                else //Si es mayor a 0.5 va al nodo B
                {
                    Objetivo = Objetivo.NodoB;
                }
            }

            //Actualiza el destino del agente
            AgenteIA.destination
                = Objetivo.transform.position;
            
        }
        
    }
}
