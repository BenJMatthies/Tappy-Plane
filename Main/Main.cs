using Godot;
using System;

public partial class Main : Control
{
    GameManager gameManager;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        gameManager = GetNode<GameManager>("/root/GameManager");
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
