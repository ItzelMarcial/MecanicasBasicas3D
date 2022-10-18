using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBomba : Item
{
    public int PuntosDanio = 30;

    public override void Activar(Character perso)
    {
        print("Aplicando efecto bomba" + perso.name);
        perso.RecibirDanio(PuntosDanio, gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}

