using System.Collections;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using TMPro;

public class Login : MonoBehaviour
{
    public string url = "http://localhost/prueba.php";
    public TMP_InputField emailInputField;
    public TMP_InputField passwordInputField;
    public Button loginButton;
    [SerializeField] LoginData loginData;

    public GameObject successPanel;

    void Start()
    {
        // Asegurate de que el bot?n tenga asignado el evento de clic
        loginButton.onClick.AddListener(OnLoginButtonClicked);

        if (successPanel != null)
            successPanel.SetActive(false);
    }

    void OnLoginButtonClicked()
    {
        loginData.email = emailInputField.text;
        loginData.password = passwordInputField.text;

        print(loginData.email + " " + loginData.password);
        StartCoroutine(TryLogin());
    }
    IEnumerator TryLogin()
    {
        string jsonData = JsonUtility.ToJson(loginData);
        byte[] jsonToSend = Encoding.UTF8.GetBytes(jsonData);

        UnityWebRequest request = new UnityWebRequest(url, "POST");
        request.uploadHandler = new UploadHandlerRaw(jsonToSend);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.ConnectionError ||
            request.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.LogError("Error: " + request.error);
        }
        else
        {
            string responseText = request.downloadHandler.text;
            Debug.Log("Respuesta: " + responseText);

            // Si el servidor manda algún texto como "Conectado" antes del JSON, recortamos
            int jsonStart = responseText.IndexOf('{');
            if (jsonStart != -1)
            {
                responseText = responseText.Substring(jsonStart);
            }

            LoginResponse response = JsonUtility.FromJson<LoginResponse>(responseText);

            if (response.status == "success")
            {
                Debug.Log("Bienvenido: " + response.user.username);
                successPanel.SetActive(true);
            }
            else
            {
                Debug.LogWarning("Login fallido");
            }
        }
    }
}
[System.Serializable]
public class LoginData
{
    public string email;
    public string password;
}

[System.Serializable]
public class User
{
    public int id;
    public string username;
    public string email;
    public string created_at;
}

[System.Serializable]
public class LoginResponse
{
    public string status;
    public User user;
}