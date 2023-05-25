using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private Transform panel;

    [SerializeField] private TextMeshProUGUI killText;
    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private TextMeshProUGUI levelText;

    [SerializeField] private Button mainMenuButton;

    private void Awake()
    {
        mainMenuButton.onClick.AddListener(() =>
        {
            Loader.Load(Loader.Scene.MenuScene);
        });
        Time.timeScale = 1.0f;
    }

    private void Start()
    {
        GameManager.Instance.OnGameOver += GameManager_OnGameOver;
    }

    private void GameManager_OnGameOver(object sender, System.EventArgs e)
    {
        InitScore();
    }

    public void InitScore()
    {
        panel.gameObject.SetActive(true);
        float time = GameManager.Instance.GetTimer();
        string min = Mathf.Floor(time / 60).ToString("00");
        string sec = (time % 60).ToString("00");
        
        killText.text = GameManager.Instance.GetKill().ToString();
        timeText.text = $"{min}:{sec}";
        levelText.text = Player.Instance.GetLevel().ToString();

        if (GameInput.Instance.IsGamepad())
            mainMenuButton.Select();
    }
}
