using UnityEngine;

public class GenObject : MonoBehaviour
{
    // Prefab que se va a instanciar
    public GameObject prefab;

    // Transform del objeto de referencia donde se instanciar� el prefab
    public Transform referenceTransform;

    // Desplazamiento en el eje Y
    public float yOffset = 0f;

    // Color del Gizmo
    public Color gizmoColor = Color.red;

    // Tama�o del cuadrado en el eje X y Z
    public float squareWidth = 1f;
    public float squareHeight = 1f;

    // N�mero de prefabs a instanciar
    public int numberOfPrefabs = 10;

    // Mostrar u ocultar el Gizmo
    public bool showGizmo = true;

    // Rotaci�n espec�fica del prefab
    public Vector3 prefabRotation = new Vector3(37f, 90f, 47f);

    void Update()
    {
        // Detectar si se ha presionado la barra espaciadora
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Verificar si el prefab y el transform de referencia est�n asignados
            if (prefab != null && referenceTransform != null)
            {
                // Convertir la rotaci�n de euler a Quaternion
                Quaternion rotation = Quaternion.Euler(prefabRotation);

                // Instanciar varios prefabs en posiciones aleatorias dentro del �rea
                for (int i = 0; i < numberOfPrefabs; i++)
                {
                    // Crear una posici�n aleatoria dentro del cuadrado
                    Vector3 randomPosition = new Vector3(
                        Random.Range(referenceTransform.position.x - squareWidth / 2, referenceTransform.position.x + squareWidth / 2),
                        referenceTransform.position.y + yOffset,
                        Random.Range(referenceTransform.position.z - squareHeight / 2, referenceTransform.position.z + squareHeight / 2)
                    );

                    // Instanciar el prefab en la posici�n aleatoria con la rotaci�n espec�fica
                    Instantiate(prefab, randomPosition, rotation);
                }
            }
            else
            {
                Debug.LogError("Prefab o Transform de referencia no asignados.");
            }
        }
    }

    // Dibujar un cuadrado en los ejes X y Z
    private void OnDrawGizmos()
    {
        // Solo dibujar el Gizmo si showGizmo est� activado
        if (showGizmo && referenceTransform != null)
        {
            // Definir el color del Gizmo
            Gizmos.color = gizmoColor;

            // Posici�n en la que se dibujar� el Gizmo
            Vector3 centerPosition = new Vector3(
                referenceTransform.position.x,
                referenceTransform.position.y + yOffset,
                referenceTransform.position.z
            );

            // Dibujar el cuadrado usando l�neas
            Vector3 topLeft = centerPosition + new Vector3(-squareWidth / 2, 0, -squareHeight / 2);
            Vector3 topRight = centerPosition + new Vector3(squareWidth / 2, 0, -squareHeight / 2);
            Vector3 bottomLeft = centerPosition + new Vector3(-squareWidth / 2, 0, squareHeight / 2);
            Vector3 bottomRight = centerPosition + new Vector3(squareWidth / 2, 0, squareHeight / 2);

            Gizmos.DrawLine(topLeft, topRight);
            Gizmos.DrawLine(topRight, bottomRight);
            Gizmos.DrawLine(bottomRight, bottomLeft);
            Gizmos.DrawLine(bottomLeft, topLeft);
        }
    }
}
