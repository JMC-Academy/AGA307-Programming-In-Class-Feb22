using System;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState {Title, Playing, Paused, GameOver}
public enum Difficulty {Easy, Medium, Hard}
public class GameManager : GameBehaviour<GameManager>
{
    public GameState gameState;
    public Difficulty difficulty;
    public int score;
    int scoreMultiplyer = 1;
    bool isPaused = false;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            TogglePause();
    }

    public void TogglePause()
    {
        //if (gameState != GameState.Playing || gameState != GameState.Paused)
        //    return;

        isPaused = !isPaused;
        if (isPaused)
        {
            ChangeGameState(GameState.Paused);
            Time.timeScale = 0;
        }
        else
        {
            ChangeGameState(GameState.Playing);
            Time.timeScale = 1;
        }
    }

    public void ChangeGameState(GameState _gameState)
    {
        gameState = _gameState;
        GameEvents.ReportGameStateChange(gameState);
    }

    public void ChangeDifficulty(int _difficulty)
    {
        difficulty = (Difficulty)_difficulty;

        switch (difficulty)
        {
            case Difficulty.Easy:
                scoreMultiplyer = 1;
                break;
            case Difficulty.Medium:
                scoreMultiplyer = 3;
                break;
            case Difficulty.Hard:
                scoreMultiplyer = 6;
                break;
            default:
                scoreMultiplyer = 1;
                break;
        }
    }

    public void AddScore(int _value)
    {
        score += _value * scoreMultiplyer;
        GameEvents.ReportScoreChange(score);
    }

    void OnEnemyHit(Enemy _enemy)
    {
        AddScore(10);
    }

    void OnEnemyDied(Enemy _enemy)
    {
        AddScore(100);
    }

    private void OnEnable()
    {
        GameEvents.OnEnemyHit += OnEnemyHit;
        GameEvents.OnEnemyDied += OnEnemyDied;
    }

    private void OnDisable()
    {
        GameEvents.OnEnemyHit -= OnEnemyHit;
        GameEvents.OnEnemyDied -= OnEnemyDied;
    }
}
