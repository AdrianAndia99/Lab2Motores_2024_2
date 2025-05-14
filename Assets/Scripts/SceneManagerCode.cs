using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerCode : MonoBehaviour
{
    public TextMeshProUGUI textSample;

    void Awake()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        WebGLInput.captureAllKeyboardInput = false;
#endif
    }
    public void Cambio(string nombre)
    {
        SceneManager.LoadScene(nombre);
        Time.timeScale = 1f;
    }

    public void ChangeText(string text)
    {
        textSample.text = text;
    }
    public void Restart()
    {
        SceneManager.LoadScene("MemoryCards");
    }
    public void Salir()
    {
        Debug.Log("Saliste");
        Application.Quit();
    }
}