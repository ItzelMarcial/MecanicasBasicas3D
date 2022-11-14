using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShotter : MonoBehaviour
{
    public ArmaRango MiArma;
    public Transform LaCamara;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float rotHoriz = Input.GetAxis("Mouse X");
        float rotVert = Input.GetAxis("Mouse Y");

        transform.Rotate(transform.up * rotHoriz);
        LaCamara.Rotate(LaCamara.right * -rotVert, Space.World);

        if (Input.GetButton("Fire1"))
        {
            MiArma.Disparar();
        }
    }
}
