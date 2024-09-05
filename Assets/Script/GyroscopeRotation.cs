using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroscopeControl : MonoBehaviour
{
    public float rotationSpeed = 10f; // Velocidad de rotación
    public float moveSpeed = 5f; // Velocidad de movimiento

    private Rigidbody rb;

    private void Start()
    {
        // Verifica si el dispositivo tiene giroscopio
        if (SystemInfo.supportsGyroscope)
        {
            Input.gyro.enabled = true;
        }
        else
        {
            Debug.LogError("El dispositivo no soporta giroscopio.");
        }

        // Obtiene el componente Rigidbody
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("El objeto necesita un componente Rigidbody.");
        }
    }

    private void Update()
    {
        if (rb == null) return;

        // Obtiene la rotación del giroscopio
        Quaternion gyroRotation = Input.gyro.attitude;

        // Aplica rotación al Rigidbody basado en el giroscopio
        Quaternion fixedRotation = new Quaternion(-gyroRotation.x, -gyroRotation.y, gyroRotation.z, gyroRotation.w);
        rb.rotation = fixedRotation;

        // Calcula el movimiento basado en la inclinación del giroscopio
        Vector3 movement = new Vector3(-gyroRotation.y, 0, gyroRotation.x);
        rb.velocity = movement * moveSpeed;
    }
}
