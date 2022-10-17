using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorPiso : MonoBehaviour
{
    public bool EnPiso = true;
    public float DistDeteccion = 0.1f;
    public LayerMask LayersDePiso; //lee el layer al que un objeto esta asignado
    // Update is called once per frame
    void Update()
    {
        Ray RayoDetector = new Ray(
            this.transform.position,
            Vector3.down); //Apartior de su posicion lanzar un cubo hacia abajo

        EnPiso = Physics.Raycast(RayoDetector, 
            DistDeteccion);

        

        
    }
    private void OnDrawGizmos()
    {
        //Dibuja los rayos uwu
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position,
            transform.position
            + Vector3.down * DistDeteccion);

    }
}
