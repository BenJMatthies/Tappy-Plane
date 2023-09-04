using Godot;
using System;

public partial class GameOver : Control
{
    Label GameOverLabel;
    Label PressSpaceLabel;
    Timer LabelTimer;
    bool pressSpaceEnabled;
	GameManager gameManager;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        GameOverLabel = GetNode<Label>("GameOverLabel");
        PressSpaceLabel = GetNode<Label>("PressSpaceLabel");
        LabelTimer = GetNode<Timer>("Timer");
        pressSpaceEnabled = false;
		gameManager = GetNode<GameManager>("/root/GameManager");

		Callable onGameOverCallable = new(this, "OnGameOver");
        gameManager.Connect("OnGameOver", onGameOverCallable);
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
        if (pressSpaceEnabled)
        {
            if (Input.IsActionJustPressed("fly"))
            {
                gameManager.loadMainScene();
            }
        }
    }

    private void OnGameOver()
    {
        Show();
        LabelTimer.Start();
    }

    private void SwitchVisibleLabels(bool labelSwitch)
    {
        GameOverLabel.Visible = labelSwitch;
        PressSpaceLabel.Visible = !labelSwitch;
        pressSpaceEnabled = !labelSwitch;
    }

    private void OnTimerTimeout()
    {
        SwitchVisibleLabels(false);
    }
}
