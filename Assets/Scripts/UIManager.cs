using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : GameBehaviour<UIManager>
{
    public TMP_Text scoreText;
    public GameObject mainPanel;
    public GameObject pausePanel;

    void Start()
    {
        UpdateScore(0);
    }

    void UpdateScore(int _score)
    {
        scoreText.text = "Score: " + _score;
    }

    public void ReturnToTitle()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Title");
    }

    void OnGameStateChange(GameState _gameState)
    {
        switch (_gameState)
        {
            case GameState.Playing:
                mainPanel.SetActive(true);
                pausePanel.SetActive(false);
                break;
            case GameState.Paused:
                mainPanel.SetActive(false);
                pausePanel.SetActive(true);
                break;
            case GameState.GameOver:
            case GameState.Title:
                break;
        }
    }

    private void OnEnable()
    {
        GameEvents.OnGameStateChange += OnGameStateChange;
        GameEvents.OnScoreChange += UpdateScore;
    }

    private void OnDisable()
    {
        GameEvents.OnGameStateChange -= OnGameStateChange;
        GameEvents.OnScoreChange -= UpdateScore;
    }
}
