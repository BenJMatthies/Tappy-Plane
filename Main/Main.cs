using Godot;
using System;

public partial class Main : Control
{
    GameManager gameManager;
    Label HighScoreLabel;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        gameManager = GetNode<GameManager>("/root/GameManager");
        HighScoreLabel = GetNode<Label>("MarginContainer/HBoxContainer/HighScoreLabel");

        HighScoreLabel.Text = gameManager.getHighScore().ToString();
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
        if (Input.IsActionJustPressed("fly"))
        {
            gameManager.loadGameScene();
        }
    }
}
