using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieIA : MonoBehaviour
{

    public float DistAgro = 2.5f;
    public float VelCaminado = 15f;
    private Rigidbody MiCuerpo;
    private Animator MiAnimador;
    public Transform Player;
    // Start is called before the first frame update
    void Start()
    {
        MiCuerpo = GetComponent<Rigidbody>();
        MiAnimador = GetComponent<Animator>();
        //Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
        
        MiAnimador.SetBool("EN_AREA_AGRO", EstoyCercaPlayer && !EstoyADistanciaMeele);
        MiAnimador.SetBool("ATAQUE_MEELE", EstoyADistanciaMeele);
    }

    private void OnDrawGizmos()
    {
        if(EstoyCercaPlayer)
        {
            Gizmos.color = new Color(1, 0, 0, 0.2f);//rojo
        }
        else
        {
            Gizmos.color = new Color(0, 1, 0, 0.2f);//verde
        }
        Gizmos.DrawSphere(transform.position, DistAgro);
    }

    private void FixedUpdate()
    {
        lookAt();
        if (EstoyCercaPlayer)
        {
            if(EstoyADistanciaMeele)
            {

            }
            else
            {
                MiCuerpo.velocity = transform.forward * VelCaminado * Time.fixedDeltaTime;
            }
            
            
            

        }
        


        
    }
    private bool EstoyCercaPlayer
    {
       get
        {

            if(Player != null)
            {
                float distPlayer
                = Vector3.Distance(this.transform.position,
                Player.position);
                return Mathf.Abs(distPlayer) <= DistAgro;

                
            }
            
            else
            {
                return false;
            }

            
        }
    }
    private bool EstoyADistanciaMeele
    {
        get
        {

            if (Player != null)
            {
                float distPlayer
                = Vector3.Distance(this.transform.position,
                Player.position);

                return Mathf.Abs(distPlayer) <= 0.5f;

            }

            else
            {
                return false;
            }


        }
    }

    private void lookAt()

    {
        transform.LookAt(Player.transform.position);
    }

}

