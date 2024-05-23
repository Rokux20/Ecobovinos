using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrera : MonoBehaviour
{ 
    // Variable para controlar si la barrera est� activa o no
    public bool activa = false;

    // M�todo para activar la barrera
    public void ActivarBarrera()
    {
        activa = true;

        // C�digo adicional para activar la funcionalidad de la barrera, como cambiar la apariencia, activar colisiones, etc.
    }

    // M�todo para desactivar la barrera
    public void DesactivarBarrera()
    {
        activa = false;

        // C�digo adicional para desactivar la funcionalidad de la barrera, como cambiar la apariencia, desactivar colisiones, etc.
    }

    void OnTriggerEnter(Collider col)
    {
        // Si la barrera est� activa y el objeto que colisiona con ella tiene la etiqueta "Player", se ejecuta el c�digo siguiente
        if (activa && col.tag == "Player")
        {
            // C�digo para lo que sucede cuando el jugador choca con la barrera, como restarle vida, mostrar un mensaje, etc.
        }
    }
}
