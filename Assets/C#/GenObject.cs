using UnityEngine;

public class RandomPrefabSpawner : MonoBehaviour
{
    // Prefab que se va a instanciar
    public GameObject prefab;

    // GameObject que representa el plano en el que se instanciar� el prefab
    public GameObject plane;

    // Desplazamiento en el eje Y respecto al plano
    public float yOffset = 1f;

    // N�mero de prefabs a instanciar
    public int numberOfPrefabs = 10;
    

    void Start()
    {
        // Verificar si el prefab y el plano est�n asignados
        if (prefab != null && plane != null)
        {
            // Obtener el transform del plano para calcular el centro y las dimensiones
            Transform planeTransform = plane.transform;
            Vector3 planePosition = planeTransform.position;
            Vector3 planeSize = new Vector3(12f, 0f, 12f); // Tama�o de 3x3 en el eje XZ

            // Instanciar varios prefabs en posiciones aleatorias dentro del �rea del plano
            for (int i = 0; i < numberOfPrefabs; i++)
            {
                // Crear una posici�n aleatoria dentro del �rea del plano
                Vector3 randomPosition = new Vector3(
                    Random.Range(planePosition.x - planeSize.x / 2, planePosition.x + planeSize.x / 2),
                    planePosition.y + yOffset,
                    Random.Range(planePosition.z - planeSize.z / 2, planePosition.z + planeSize.z / 2)
                );
                Instantiate(prefab, randomPosition, Quaternion.identity);
            }
        }
        else
        {
            Debug.LogError("Prefab o Plano no asignados.");
        }
    }
}
