using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController3ABlend : MonoBehaviour
{
    //Script para rotar el personaje con ayuda del mouse, haciendolo compatible con
    //la camara de 3ra persona
    public float VelocidadCaminar = 1f;
    public float FuerzaSalto = 4f;
    private Rigidbody MiCuerpo;
    private Animator MiAnimador;
    

    private DetectorPiso DetectorPiso;

    //Para ajustar el mov del mouse, para que no se vea muy feo
    public float VelRotacion = 1f;


    // Start is called before the first frame update
    void Start()
    {

        this.MiCuerpo = GetComponent<Rigidbody>();
        this.MiAnimador = GetComponent<Animator>();
        this.DetectorPiso = GetComponent<DetectorPiso>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 velActual = MiCuerpo.velocity;

        float ejeHoriz = Input.GetAxis("Horizontal");
        float ejeVert = Input.GetAxis("Vertical");
        float movMouseHoriz = Input.GetAxis("Mouse X"); //recibe el movimiento del mouse

        //Cambia la orientaciòn del objeto
        //0,1,0       Input           Regula la velocidad de movimiento
        transform.Rotate(Vector3.up * movMouseHoriz * VelRotacion);

        if (ejeHoriz != 0 || ejeVert != 0)
        {

            //Se mueve el objeto
            MiCuerpo.velocity =
                transform.forward * VelocidadCaminar * ejeVert //Esto edita la direccion frontal
                + transform.right * VelocidadCaminar * ejeHoriz //transform.right es el que va a aplicar la direccion lateral
                + Vector3.up * velActual.y; //Esto hace que si el personaje esta cayendo, caiga a una velocidad razonable
                                            //Si no se hace esto, el personaje va a caminar en el aire




        }

        if (DetectorPiso.EnPiso && Input.GetButtonDown("Jump"))
        {
            //Vector2.up (0,1) * 4(FuerzaSalto)
            MiCuerpo.AddForce(Vector2.up * FuerzaSalto,
                ForceMode.Impulse);
        }

        if(Input.GetButtonDown("Fire1"))
        {
            
            MiAnimador.SetTrigger("ATACAR");
        
        }

        MiAnimador.SetFloat("MOV_FRONT", ejeVert);
        MiAnimador.SetFloat("MOV_LATERAL", ejeHoriz);

        MiAnimador.SetBool("EN_PISO", DetectorPiso.EnPiso);





    }

    public void Hit()
    {
        
    }
}
