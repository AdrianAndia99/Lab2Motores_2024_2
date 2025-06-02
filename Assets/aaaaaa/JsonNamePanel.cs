using System.IO;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class JsonNamePanel : MonoBehaviour
{
    public GameObject buttonPrefab; // Prefab de botón con texto
    public Transform contentHolder; // Panel de contenido (ScrollView Content)
    public DataController dataController;

    public void ShowJsonList()
    {
        // Limpiar lista anterior
        foreach (Transform child in contentHolder)
        {
            Destroy(child.gameObject);
        }

        // Buscar archivos .json
        string[] files = Directory.GetFiles(Application.streamingAssetsPath, "*.json");

        foreach (string file in files)
        {
            string filename = Path.GetFileNameWithoutExtension(file);

            GameObject newButton = Instantiate(buttonPrefab, contentHolder);
            newButton.GetComponentInChildren<TMP_Text>().text = filename;

            newButton.GetComponent<Button>().onClick.AddListener(() =>
            {
                dataController.SaveProgressDataToFile(filename);
                gameObject.SetActive(false);
            });
        }

        gameObject.SetActive(true); // Activar el panel
    }
}