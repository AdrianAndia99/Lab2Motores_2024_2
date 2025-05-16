using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManagerController : MonoBehaviour
{
    public static GameManagerController Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }
    void Start()
    {
        AudioManagerController.Instance.LoadAudioSettings();
    }
    public void ChangeScene(string scene)
    {
        AudioManagerController.Instance.SaveAudioSettings();
        SceneManager.LoadScene(scene);
    }
    public void CloseGame()
    {
        Application.Quit();
    }
}
