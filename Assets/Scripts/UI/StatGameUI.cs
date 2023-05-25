using TMPro;
using UnityEngine;

public class StatGameUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private TextMeshProUGUI killText;

    private void Start()
    {
        timerText.text = "00:00";
        killText.text = "0";
    }

    private void Update()
    {
        string min = Mathf.Floor(GameManager.Instance.GetTimer() / 60).ToString("00");
        string sec = (GameManager.Instance.GetTimer() % 60).ToString("00");
        timerText.text = $"{min}:{sec}";
        killText.text = GameManager.Instance.GetKill().ToString();
    }
}
