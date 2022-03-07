using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState {Title, Playing, Paused, GameOver}
public enum Difficulty { Easy, Medium, Hard}
public class GameManager : MonoBehaviour
{
    public GameState gameState;
    public Difficulty difficulty;
    public int score;
    int scoreMultiplyer = 1;

    void Start()
    {
        gameState = GameState.Title;

        switch(difficulty)
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
}
