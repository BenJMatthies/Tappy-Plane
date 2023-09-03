using Godot;
using System;

public partial class game : Node2D
{
    PackedScene PipesScene;

    Node PipesHolder;
    Marker2D SpawnUpper;
    Marker2D SpawnLower;
    Timer SpawnTimer;
    GameManager gameManager;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        PipesScene = GD.Load<PackedScene>("res://Pipes/pipes.tscn");

        PipesHolder = GetNode<Node2D>("PipesHolder");
        SpawnUpper = GetNode<Marker2D>("SpawnUpper");
        SpawnLower = GetNode<Marker2D>("SpawnLower");
        SpawnTimer = GetNode<Timer>("SpawnTimer");
        gameManager = (GameManager)GetNode("/root/GameManager");

        gameManager.Connect("OnGameOver", OnPlaneDied());

        SpawnPipes();
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
    }

    private void SpawnPipes()
    {
        double yPosition = GD.RandRange(SpawnUpper.Position.Y, SpawnLower.Position.Y);
        Node2D newPipes = (Node2D)PipesScene.Instantiate();
        newPipes.Position = new Vector2(SpawnLower.Position.X, (float)yPosition);
        PipesHolder.AddChild(newPipes);
    }

    private void OnSpawnTimerTimeout()
    {
        SpawnPipes();
    }

    private void OnPlaneDied()
    {
        gameManager.loadMainScene();
    }
}
