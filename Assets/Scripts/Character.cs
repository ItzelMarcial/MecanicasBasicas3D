using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public int HP;
    public ArmaMelee MiArma;
    public int dmg;
    private Animator MiAnimador;

    private void Start()
    {
        this.MiAnimador = GetComponent<Animator>();
    }

    public void IniciarAtaque()
    {
        MiArma.MiCollider.enabled = true;
    }
    public void TerminarAtaque()
    {
        MiArma.MiCollider.enabled = false; 
    }    
    public void RecibirDanio(int puntos, GameObject origen)
    {
        HP -= puntos;
        print(this + " recibe " + puntos + " de danio por " + origen);

        if(HP > 0)
        {
            MiAnimador.SetTrigger("DANIO");
        }
        if(HP <= 0)
        {
            MiAnimador.SetTrigger("MUERTE");
            Invoke("DestruirDespuesDeMorir", 5);
        }
        
    }

    void DestruirDespuesDeMorir()
    {
        Destroy(gameObject);
    }
}
