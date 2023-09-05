using Godot;
using System;

public partial class Hud : Control
{
    Label ScoreLabel;
    GameManager gameManager;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        ScoreLabel = GetNode<Label>("MarginContainer/ScoreLabel");
        gameManager = GetNode<GameManager>("/root/GameManager");

        Callable onScoreUpdatedCallable = new(this, "OnScoreUpdated");
        gameManager.Connect("OnScoreUpdated", onScoreUpdatedCallable);

        OnScoreUpdated();
    }

    private void OnScoreUpdated()
    {
        ScoreLabel.Text = gameManager.getScore().ToString();
    }
}
