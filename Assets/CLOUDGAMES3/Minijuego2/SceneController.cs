using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using UnityEngine.UI;
using System.Threading;
using TMPro;
public class SceneController : MonoBehaviour
{
    [SerializeField] private GameObject panelDefeat;
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private TextMeshProUGUI finalTimerText;
    [SerializeField] private TextMeshProUGUI nameTEXT;


    private float timeElapsed = 0f;
    private bool isPlayerAlive = true;

    private void OnEnable()
    {
        Ball.OnDefeat += LoadDefeatScene;
    }

    private void OnDisable()
    {

        Ball.OnDefeat -= LoadDefeatScene;
    }

     private void Awake()
    {

#if UNITY_WEBGL && !UNITY_EDITOR
            WebGLInput.captureAllKeyboardInput = false;
#endif

    }
    void Update()
    {
        if (isPlayerAlive)
        {
            timeElapsed += Time.deltaTime;
            UpdateTimerUI();
        }
    }
    void UpdateTimerUI()
    {
        int minutes = Mathf.FloorToInt(timeElapsed / 60f);
        int seconds = Mathf.FloorToInt(timeElapsed % 60f);
        timerText.text = $"{minutes:00}:{seconds:00}";
    }
    public void LoadDefeatScene()
    {
        isPlayerAlive = false;
        panelDefeat.SetActive(true);
        finalTimerText.text = $"�Sobreviviste {timerText.text}";
    }
    public void ChangeText(string text)
    {
        nameTEXT.text = text;
    }
    public void RestartGame()
    {
        SceneManager.LoadScene("MiniJuego2");
    }
    public void loadScene(string scen)
    {
        SceneManager.LoadScene(scen);
    }
}