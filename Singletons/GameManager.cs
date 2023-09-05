using Godot;
using System;

public partial class GameManager : Node
{
    [Signal] public delegate void OnGameOverEventHandler();
    [Signal] public delegate void OnScoreUpdatedEventHandler();

    private int _score = 0;
    private int _highScore = 0;

    public int getScore()
    {
        return _score;
    }

    public int getHighScore()
    {
        return _highScore;
    }

    public void setScore(int value)
    {
        _score = value;
        if (_score > _highScore) _highScore = _score;
        EmitSignal("OnScoreUpdated");
    }

    public void incrementScore()
    {
        setScore(_score + 1);
    }

    public void loadGameScene()
    {
        GetTree().ChangeSceneToPacked(GD.Load<PackedScene>("res://Game/game.tscn"));
    }

    public void loadMainScene()
    {
        GetTree().ChangeSceneToPacked(GD.Load<PackedScene>("res://Main/Main.tscn"));
    }
}
