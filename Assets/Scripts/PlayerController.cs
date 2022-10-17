using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float VelocidadCaminar = 1f;
    private Rigidbody MiCuerpo;
    private Animator MiAnimador;

    // Start is called before the first frame update
    void Start()
    {
        this.MiCuerpo = GetComponent<Rigidbody>();
        this.MiAnimador = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float ejeHoriz = Input.GetAxis("Horizontal");
        float ejeVert = Input.GetAxis("Vertical");

        if(ejeHoriz != 0 || ejeVert != 0)
        {
            //Cambia la orientaciòn del objeto
            transform.forward = new Vector3(ejeHoriz, 0, ejeVert);

            MiCuerpo.velocity = transform.forward * VelocidadCaminar;

           

            //dECIRLE AL ANIMADOR QUE MUESTRE LA ANIMACION DE 
            //CAMINAR USANDO EL PARAMETRO DE VEL-CAMINADO
        }

        MiAnimador.SetFloat("VEL_CAMINADO", MiCuerpo.velocity.magnitude);
        

        
        

    }
}
