using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaNueva : Item
{
    public bool Atacando = true;
    public ArmaMelee NuevaArma;
    
    public Transform Posicion;

    public Collider ArmaNuevaCollider;

    public override void Activar(Character perso)
    {
        Posicion = perso.MiArma.transform.parent;

        ArmaMelee nuevaArma = Instantiate(NuevaArma, Posicion);
        

        Destroy(perso.MiArma.gameObject);

        perso.MiArma = nuevaArma;

    }

    
    

}
