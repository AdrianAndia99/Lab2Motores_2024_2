using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIManagerController : MonoBehaviour
{
    public static UIManagerController Instance { get; private set; }
    [SerializeField] private GameObject controlsMenu;
    [SerializeField] private GameObject optionsMenu;
    [SerializeField] private GameObject creditsMenu;
    [SerializeField] public Slider lifeBar;
    [SerializeField] private TMP_Text lifeText;
    [SerializeField] private TMP_Text enemiesEliminatedText; // El contador de enemigos eliminados
    public GameData gameData;
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
    public void ActiveControlsMenu()
    {
        controlsMenu.SetActive(true);
        controlsMenu.GetComponent<Image>().raycastTarget = true;
    }
    public void DisableControlsMenu()
    {
        controlsMenu.SetActive(false);
        controlsMenu.GetComponent<Image>().raycastTarget = false;
    }
    public void ActiveOptionsMenu()
    {
        optionsMenu.SetActive(true);
        optionsMenu.GetComponent<Image>().raycastTarget = true;
        Time.timeScale = 0;
    }
    public void DisableOptionsMenu()
    {
        optionsMenu.SetActive(false);
        optionsMenu.GetComponent<Image>().raycastTarget = false;
        Time.timeScale = 1;
    }
    public void ActiveCreditsMenu()
    {
        creditsMenu.SetActive(true);
        creditsMenu.GetComponent<Image>().raycastTarget = true;
    }
    public void DisableCreditsMenu()
    {
        creditsMenu.SetActive(false);
        creditsMenu.GetComponent<Image>().raycastTarget = false;
    }
    public void UpdatePlayerLife(int playerLife)
    {
        lifeBar.value = playerLife;
        lifeText.text = playerLife.ToString();
    }
    public void EnemyEliminated()
    {
        gameData.enemiesEliminated++;
        enemiesEliminatedText.text = gameData.enemiesEliminated.ToString();
    }
    public void ShowEnemiesEliminated()
    {
        enemiesEliminatedText.text = gameData.enemiesEliminated.ToString();
        gameData.enemiesEliminated = 0;
    }
}
