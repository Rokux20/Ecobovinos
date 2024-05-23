using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ventilador : MonoBehaviour
{

    // Variable para controlar si el movimiento est� activo
    public bool movimientoActivo = false;

    // Velocidad de rotaci�n del panel solar
    public float velocidadRotacion = 10f;

    // M�todo Update para el movimiento del panel solar
    void Update()
    {
        // Si el movimiento est� activo, rota el panel solar
        if (movimientoActivo)
        {
            // Rotaci�n del panel solar en su propio eje Y
            transform.Rotate(0f, 10f * Time.deltaTime, 0f, Space.Self);
        }
    }

    // M�todo p�blico para activar el movimiento del panel solar
    public void ActivarMovimiento()
    {
        movimientoActivo = true; // Establece la variable de movimiento activo en true
    }

    // M�todo para desactivar el movimiento del panel solar
    public void DesactivarMovimiento()
    {
        movimientoActivo = false; // Establece la variable de movimiento activo en false
    }

    // M�todo para activar autom�ticamente el movimiento al completar la misi�n
    public void ActivarMovimientoAlCompletarMision()
    {
        ActivarMovimiento(); // Llamamos al m�todo que activa el movimiento
    }
}