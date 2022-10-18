using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCura : Item
{

    public int PuntosHP;

    public override void Activar(
        Character perso)
    {
        print("Aplicando Efecto curacion");
        perso.HP += PuntosHP;
    }
    
}
