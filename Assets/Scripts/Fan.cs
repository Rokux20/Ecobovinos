using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan : MonoBehaviour
{
    public float rotationSpeed = 100f; // Velocidad de rotación de la rueda
    public float swirlForce = 10f; // Fuerza del remolino

    // Update is called once per frame
    void Update()
    {
        // Rotar la rueda
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);

        // Aplicar una fuerza de remolino
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(Vector3.right * swirlForce);
        }
    }
}
