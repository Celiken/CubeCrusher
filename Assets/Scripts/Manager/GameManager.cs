using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public event EventHandler OnGameOver;

    private float timer;
    private int kill;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        StartGame();
        XPManager.Instance.OnLevelUp += XPManager_OnLevelUp;
    }

    private void XPManager_OnLevelUp(object sender, EventArgs e)
    {
        SpawnerManager.Instance.IncreaseSpawnRate();
    }

    public void StartGame()
    {
        timer = 0f;
        kill = 0;
    }

    public void EndGame()
    {
        Time.timeScale = 0f;
        OnGameOver?.Invoke(this, EventArgs.Empty);
    }

    private void Update()
    {
        timer += Time.deltaTime;
    }

    public float GetTimer()
    {
        return timer;
    }

    public void AddKill()
    {
        kill++;
    }

    public int GetKill()
    {
        return kill;
    }
}
