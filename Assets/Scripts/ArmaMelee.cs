using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaMelee : MonoBehaviour
{
    public enum Elementos
    {
        Fuego, Tierra, Aire, Agua
    }

    public bool Atacando = false;
    public int PtsDanio = 25;
    public Elementos Elemento = Elementos.Tierra;
    public string TagDueñoArma;

    private Collider MiCollider;

    // Start is called before the first frame update
    void Start()
    {
        MiCollider = GetComponent<Collider>();
        
        this.TagDueñoArma = gameObject.tag;
        print(this + "es el arma de" + TagDueñoArma);

    }

    // Update is called once per frame
    void Update()
    {
        MiCollider.enabled = Atacando;
    }

    private void OnTriggerEnter(Collider other)
    {
        Character oponente = other.gameObject.GetComponent<Character>();
        
        if (oponente != null)
        {
            if(!other.gameObject.CompareTag(TagDueñoArma))
            {
                oponente.RecibirDanio(PtsDanio, gameObject);
            }
            
        }
    }

   
}
