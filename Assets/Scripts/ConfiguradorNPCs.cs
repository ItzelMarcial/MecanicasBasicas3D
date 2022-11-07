using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfiguradorNPCs : MonoBehaviour
{
    public NodoRuta NodoInicial;
    public SortingLayer NPCLayer;

    public void Configurar(GameObject generador, 
        GameObject npc)
    {
        //el segundo recibe el npc
        //A cada npc creado de se le agrega el script de NPCCaminante
        NPCCaminante caminante = 
            npc.AddComponent<NPCCaminante>();

        
        caminante.Objetivo = NodoInicial; //Esto aparecera enel inspector, para que agreguemos el mismo
        //nodo que usa JoshNPC

    }
}
