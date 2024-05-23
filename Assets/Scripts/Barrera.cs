using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrera : MonoBehaviour
{ 
    // Variable para controlar si la barrera está activa o no
    public bool activa = false;

    // Método para activar la barrera
    public void ActivarBarrera()
    {
        activa = true;

        // Código adicional para activar la funcionalidad de la barrera, como cambiar la apariencia, activar colisiones, etc.
    }

    // Método para desactivar la barrera
    public void DesactivarBarrera()
    {
        activa = false;

        // Código adicional para desactivar la funcionalidad de la barrera, como cambiar la apariencia, desactivar colisiones, etc.
    }

    void OnTriggerEnter(Collider col)
    {
        // Si la barrera está activa y el objeto que colisiona con ella tiene la etiqueta "Player", se ejecuta el código siguiente
        if (activa && col.tag == "Player")
        {
            // Código para lo que sucede cuando el jugador choca con la barrera, como restarle vida, mostrar un mensaje, etc.
        }
    }
}
