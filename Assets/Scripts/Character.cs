using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public int HP;
    public ArmaMelee MiArma;

    public GameObject SangrePrefab;

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
        RecibirDanio(puntos, origen, Vector3.positiveInfinity);
    }

    public void RecibirDanio(int puntos, GameObject origen, Vector3 puntoGolpe)
    {
        HP -= puntos;
        print(this + " recibe " + puntos + " de danio por " + origen);

        if(puntoGolpe != Vector3.positiveInfinity)
        {
            Vector3 direccionGolpe = (puntoGolpe - gameObject.transform.position).normalized;
            //Le resta para sacar la particula en un punto determinado

            GameObject partSangre = Instantiate(SangrePrefab);
            partSangre.transform.position = puntoGolpe;

            partSangre.transform.forward = direccionGolpe; //La particula de sangre aldra en la direccion que recibio el golpe

        }

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
