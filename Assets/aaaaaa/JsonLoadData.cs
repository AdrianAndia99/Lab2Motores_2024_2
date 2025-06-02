using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class JsonLoadData : MonoBehaviour
{
    public GameObject buttonPrefab;
    public Transform contentHolder;
    public DataController dataController;

    public void ShowJsonList()
    {
        foreach (Transform child in contentHolder)
        {
            Destroy(child.gameObject);
        }

        string[] files = Directory.GetFiles(Application.streamingAssetsPath, "*.json");

        foreach (string file in files)
        {
            string filename = Path.GetFileNameWithoutExtension(file);

            GameObject newButton = Instantiate(buttonPrefab, contentHolder);
            newButton.GetComponentInChildren<TMP_Text>().text = filename;

            newButton.GetComponent<Button>().onClick.AddListener(() =>
            {
                dataController.LoadProgressDataFromFile(filename);
                gameObject.SetActive(false);
            });
        }

        gameObject.SetActive(true);
    }
}
