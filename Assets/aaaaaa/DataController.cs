using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.IO;
public class DataController : MonoBehaviour
{
    public TMP_InputField totalScoreInput;
    public TMP_InputField[] levelInputs = new TMP_InputField[5];
    public TMP_InputField fileNameInput;
    public Button createButton;
    public Button saveOverwriteButton;
    public Button loadDataButton;

    public JsonNamePanel fileListPanel;
    public JsonLoadData loadPanel;


    private void Start()
    {
        createButton.onClick.AddListener(SaveNewProgressData);
        saveOverwriteButton.onClick.AddListener(ShowOverwriteOptions);
        loadDataButton.onClick.AddListener(ShowLoadOptions);
    }

    private ProgressData CreateProgressDataFromInputs()
    {
        ProgressData data = new ProgressData();
        int.TryParse(totalScoreInput.text, out data.totalScore);
        for (int i = 0; i < levelInputs.Length; i++)
            int.TryParse(levelInputs[i].text, out data.levels[i]);

        return data;
    }

    private void SaveNewProgressData()
    {
        string fileName = fileNameInput.text;
        if (string.IsNullOrEmpty(fileName))
        {
            Debug.LogWarning("File name is empty.");
            return;
        }

        SaveProgressDataToFile(fileName);
    }

    public void SaveProgressDataToFile(string fileName)
    {
        ProgressData data = CreateProgressDataFromInputs();
        string json = JsonUtility.ToJson(data, true);
        string fullPath = Path.Combine(Application.streamingAssetsPath, fileName + ".json");

        File.WriteAllText(fullPath, json);
        Debug.Log("Data saved to: " + fullPath);
    }
    public void LoadProgressDataFromFile(string fileName)
    {
        string fullPath = Path.Combine(Application.streamingAssetsPath, fileName + ".json");

        if (File.Exists(fullPath))
        {
            string json = File.ReadAllText(fullPath);
            ProgressData data = JsonUtility.FromJson<ProgressData>(json);

            // Cargar en los input fields
            totalScoreInput.text = data.totalScore.ToString();
            for (int i = 0; i < levelInputs.Length && i < data.levels.Length; i++)
            {
                levelInputs[i].text = data.levels[i].ToString();
            }

            fileNameInput.text = fileName; // opcional, si quieres mostrar el nombre actual
            Debug.Log("Data loaded from: " + fullPath);
        }
        else
        {
            Debug.LogWarning("File not found: " + fullPath);
        }
    }

    private void ShowOverwriteOptions()
    {
        fileListPanel.ShowJsonList();
    }
    public void ShowLoadOptions()
    {
        loadPanel.ShowJsonList();
    }
}