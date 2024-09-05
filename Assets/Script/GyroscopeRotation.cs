using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroscopeRotation : MonoBehaviour
{

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
    }

    private void Update()
    {
        Quaternion rotation = Input.gyro.attitude;

        transform.rotation = new Quaternion(-rotation.x, -rotation.y, rotation.z, rotation.w);

        transform.Rotate(Vector3.up, rotation.y * 10f);
        transform.Rotate(Vector3.right, rotation.x * 10f);
    }
}
