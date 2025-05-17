using System.Collections;
using UnityEngine;

public class BackgroundGenerator : MonoBehaviour
{
    public GameObject[] objectsToGenerate; // Arreglo de objetos a generar
    public float[] generationTimes; // Arreglo de tiempos de generación
    public float[] yPositions; // Arreglo de posiciones Y para cada objeto

    private void Start()
    {
        if (objectsToGenerate.Length != generationTimes.Length || objectsToGenerate.Length != yPositions.Length)
        {
            Debug.LogError("Los arreglos objectsToGenerate, generationTimes y yPositions deben tener la misma longitud.");
            return;
        }

        for (int i = 0; i < objectsToGenerate.Length; i++)
        {
            StartCoroutine(GenerateObject(objectsToGenerate[i], generationTimes[i], yPositions[i]));
        }
    }

    private IEnumerator GenerateObject(GameObject obj, float delay, float yPos)
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);

            // Genera el objeto en una posición Y aleatoria entre -yPos y yPos
            float randomY = Random.Range(-yPos, yPos);
            Vector3 spawnPosition = new Vector3(transform.position.x, randomY,0);

            Instantiate(obj, spawnPosition, Quaternion.identity);
        }
    }
}
