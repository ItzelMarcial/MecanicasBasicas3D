using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodoRuta : MonoBehaviour
{
    //Los nodos son la estructura para poder navegar
    public NodoRuta NodoA;
    public NodoRuta NodoB;

    void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta; //Representa el nodo
        Gizmos.DrawSphere(
            transform.position, //position del nodo
            0.3f);
        if(NodoA != null)
        {
            Gizmos.DrawLine(
            transform.position,
            NodoA.transform.position);
        }

        if (NodoB != null)
        {
            Gizmos.DrawLine(
            transform.position,
            NodoB.transform.position);
        }
        
    }

    
    
}
