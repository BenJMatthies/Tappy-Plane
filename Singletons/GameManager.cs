using Godot;
using System;

public partial class GameManager : Node
{
    [Signal]
    public delegate void OnGameOverEventHandler();

    public void loadGameScene()
    {
        GetTree().ChangeSceneToPacked(GD.Load<PackedScene>("res://Game/game.tscn"));
        // GetTree().Root.AddChild(GameScene.Instantiate());
        // GetTree().ChangeSceneToPacked(GameScene);
    }

    public void loadMainScene()
    {
        GetTree().ChangeSceneToPacked(GD.Load<PackedScene>("res://Main/Main.tscn"));
    }
}
