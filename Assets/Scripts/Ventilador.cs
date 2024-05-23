using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ventilador : MonoBehaviour
{

    // Variable para controlar si el movimiento está activo
    public bool movimientoActivo = false;

    // Velocidad de rotación del panel solar
    public float velocidadRotacion = 10f;

    // Método Update para el movimiento del panel solar
    void Update()
    {
        // Si el movimiento está activo, rota el panel solar
        if (movimientoActivo)
        {
            // Rotación del panel solar en su propio eje Y
            transform.Rotate(0f, 10f * Time.deltaTime, 0f, Space.Self);
        }
    }

    // Método público para activar el movimiento del panel solar
    public void ActivarMovimiento()
    {
        movimientoActivo = true; // Establece la variable de movimiento activo en true
    }

    // Método para desactivar el movimiento del panel solar
    public void DesactivarMovimiento()
    {
        movimientoActivo = false; // Establece la variable de movimiento activo en false
    }

    // Método para activar automáticamente el movimiento al completar la misión
    public void ActivarMovimientoAlCompletarMision()
    {
        ActivarMovimiento(); // Llamamos al método que activa el movimiento
    }
}