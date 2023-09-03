using Godot;
using System;

public partial class GameOver : Control
{
    Label GameOverLabel;
    Label PressSpaceLabel;
    Timer LabelTimer;
    bool pressSpaceEnabled;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        GameOverLabel = GetNode<Label>("GameOverLabel");
        PressSpaceLabel = GetNode<Label>("PressSpaceLabel");
        LabelTimer = GetNode<Timer>("Timer");
        pressSpaceEnabled = false;

        endGame();
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
        if (pressSpaceEnabled)
        {
            if (Input.IsActionJustPressed("fly"))
            {
                GameManager gameManager = (GameManager)GetNode("/root/GameManager");
                gameManager.loadMainScene();
            }
        }
    }

    private void endGame()
    {
        Show();
        LabelTimer.Start();
    }

    private void switchVisibleLabels(bool labelSwitch)
    {
        GameOverLabel.Visible = labelSwitch;
        PressSpaceLabel.Visible = !labelSwitch;
        pressSpaceEnabled = !labelSwitch;
    }

    private void OnTimerTimeout()
    {
        switchVisibleLabels(false);
    }
}
