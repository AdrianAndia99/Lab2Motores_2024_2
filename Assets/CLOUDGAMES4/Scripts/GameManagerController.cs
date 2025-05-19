using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class GameManagerController : MonoBehaviour
{
    public TextMeshProUGUI textSample;

    private void Awake()
    {

#if UNITY_WEBGL && !UNITY_EDITOR
            WebGLInput.captureAllKeyboardInput = false;
#endif

    }

    public void ChangeScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
    public void ChangeText(string text)
    {
        textSample.text = text;
    }
    public void RestartGame()
    {
        SceneManager.LoadScene("Menu");
    }
}