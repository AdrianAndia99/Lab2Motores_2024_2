using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using UnityEngine.UI;
public class SceneController : MonoBehaviour
{
    [SerializeField] private GameObject panelDefeat;
    private void OnEnable()
    {
        Ball.OnDefeat += LoadDefeatScene;
    }

    private void OnDisable()
    {

        Ball.OnDefeat -= LoadDefeatScene;
    }

    private void LoadDefeatScene()
    {
        SceneManager.LoadScene("Defeat");
    }
}