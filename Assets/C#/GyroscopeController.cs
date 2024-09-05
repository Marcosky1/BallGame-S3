using UnityEngine;

public class GyroscopeController : MonoBehaviour
{
    private Gyroscope gyro;
    private bool gyroEnabled;

    public float speed = 1.0f;  // Velocidad de movimiento basada en el giroscopio

    void Start()
    {
        // Verifica si el dispositivo soporta giroscopio
        if (SystemInfo.supportsGyroscope)
        {
            gyro = Input.gyro;
            gyro.enabled = true;
            gyroEnabled = true;
        }
        else
        {
            gyroEnabled = false;
            Debug.LogWarning("Giroscopio no soportado en este dispositivo.");
        }
    }

    void Update()
    {
        if (gyroEnabled)
        {
            // Obtiene la actitud del giroscopio en forma de cuaternión
            Quaternion attitude = gyro.attitude;

            // Convierte el cuaternión a una rotación en grados
            Vector3 rotationEuler = attitude.eulerAngles;

            // Calcula el movimiento basado en la rotación del giroscopio
            Vector3 movement = new Vector3(rotationEuler.x, 0, rotationEuler.y) * speed * Time.deltaTime;

            // Aplica el movimiento a la pelota
            transform.position += movement;

            // Mantiene la posición Y constante en 0.5
            transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);
        }
    }
}
