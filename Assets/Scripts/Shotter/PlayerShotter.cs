using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShotter : MonoBehaviour
{
    public ArmaRango MiArma;
    public Camera LaCamara;
    private Animator MiAnimador;
    public GameObject MirilaApuntar;
    public float FoVApuntar = 30;
    public float FoVNormal = 60;

    public float PtsConcentracion = 100;
    public float ConsumoConcentracion = 10; 
    public float RecuperacionConcentracion = 5f;
    public float MaxPuntosConcentracion = 100f;
    public Image BarraConcentracion;

    private bool PenaltiConcenctracion = false;


    public Animator AnimadorAvatar; //Acceso al Animator del avatar

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        this.MiAnimador = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float rotHoriz = Input.GetAxis("Mouse X");
        float rotVert = Input.GetAxis("Mouse Y");

        //pONER UN BOTON EN SETTINGS XD
        //Letra s uwu
            //Aquì poner l boton de agachado para que se hagan las animavioners de agacharse jsjs
            MiAnimador.SetBool("AGACHARSE", Input.GetButton("Bow"));
           
        //transform.Rotate(transform.up * rotHoriz); originales
        //LaCamara.Rotate(LaCamara.right * -rotVert, Space.World); originales
        //lo unico que cambie, fue el mundo, para que el pivote y el vector forward se puedan mover,
        //de global lo pasé a local, es más inestable pero funciona hasta el moemnto.
        transform.Rotate(transform.up * rotHoriz); 
        
        LaCamara.transform.Rotate(LaCamara.transform.right * rotVert, Space.World); 


        if (Input.GetButton("Fire1")) //Ctrl o clic xd
        {
            MiArma.Disparar();
        }

        if(Input.GetButton("Fire2")) //Alt 
        {

            
            if (PtsConcentracion > 0)
            {
                MirilaApuntar.SetActive(true);
                LaCamara.fieldOfView = Mathf.Lerp(LaCamara.fieldOfView, FoVApuntar, Time.deltaTime * 5); //Propiedad de la camara
                //El lerp es para que la mirilla apuntr aparezca lentamente
                Time.timeScale = 0.50f;
                //PtsConcentracion -= ConsumoConcentracion * (Time.deltaTime * 2); //Aproximadamente cada 10 segundos se acaba

                PtsConcentracion = PtsConcentracion - ConsumoConcentracion * (Time.deltaTime / Time.timeScale);

                

            }
            else
            {
                MirilaApuntar.SetActive(false);
                LaCamara.fieldOfView = FoVNormal;
                Time.timeScale = 1f; //Volvemnos a la velocidad normal?
                if (PtsConcentracion <= 0)
                {
                    PenaltiConcenctracion = true;
                }
            }

        }
        else
        {
            MirilaApuntar.SetActive(false);
            LaCamara.fieldOfView = FoVNormal;
            Time.timeScale = 1f; //Volvemnos a la velocidad normal?

            if(PtsConcentracion < MaxPuntosConcentracion)
            {
                PtsConcentracion = Mathf.Clamp(PtsConcentracion + RecuperacionConcentracion * Time.deltaTime / Time.timeScale, 0, MaxPuntosConcentracion);
            }
            if(PtsConcentracion >= MaxPuntosConcentracion)
            {
                PenaltiConcenctracion = false;
            }
        }

        BarraConcentracion.fillAmount = 
            PtsConcentracion / MaxPuntosConcentracion;
        BarraConcentracion.color = PenaltiConcenctracion ? Color.red : Color.blue;

       if(PtsConcentracion / MaxPuntosConcentracion >= 0.5)
        {
            BarraConcentracion.color = Color.blue;
        }
    }
}
