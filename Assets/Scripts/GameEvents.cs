using System;

public static class GameEvents
{
    public static event Action<Enemy> OnEnemyHit = null;
    public static event Action<Enemy> OnEnemyDied = null;

    public static event Action<GameState> OnGameStateChange = null;
    public static event Action<Difficulty> OnDifficultyChange = null;
    public static event Action<int> OnScoreChange = null;

    public static void ReportEnemyHit(Enemy _enemy)
    {
        OnEnemyHit?.Invoke(_enemy);
    }

    public static void ReportEnemyDied(Enemy _enemy)
    {
        OnEnemyDied?.Invoke(_enemy);
    }

    public static void ReportGameStateChange(GameState _gameState)
    {
        OnGameStateChange?.Invoke(_gameState);
    }

    public static void ReportDifficultyChange(Difficulty _difficulty)
    {
        OnDifficultyChange?.Invoke(_difficulty);
    }

    public static void ReportScoreChange(int _score)
    {
        OnScoreChange?.Invoke(_score);
    }

}