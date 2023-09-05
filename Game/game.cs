using Godot;
using System;

public partial class game : Node2D
{
    PackedScene PipesScene;
    Node PipesHolder;
    Marker2D SpawnUpper;
    Marker2D SpawnLower;
    Timer SpawnTimer;
    AudioStreamPlayer EngineSound;
    AudioStreamPlayer GameOverSound;
    GameManager gameManager;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        //Properties
        PipesScene = GD.Load<PackedScene>("res://Pipes/pipes.tscn");
        PipesHolder = GetNode<Node2D>("PipesHolder");
        SpawnUpper = GetNode<Marker2D>("SpawnUpper");
        SpawnLower = GetNode<Marker2D>("SpawnLower");
        SpawnTimer = GetNode<Timer>("SpawnTimer");
        EngineSound = GetNode<AudioStreamPlayer>("EngineSound");
        GameOverSound = GetNode<AudioStreamPlayer>("GameOverSound");
        gameManager = GetNode<GameManager>("/root/GameManager");

        //Ready Logic
        gameManager.setScore(0);

        Callable onGameOverCallable = new(this, "OnGameOver");
        gameManager.Connect("OnGameOver", onGameOverCallable);

        SpawnPipes();
    }

    private void SpawnPipes()
    {
        double yPosition = GD.RandRange(SpawnUpper.Position.Y, SpawnLower.Position.Y);
        Node2D newPipes = (Node2D)PipesScene.Instantiate();
        newPipes.Position = new Vector2(SpawnLower.Position.X, (float)yPosition);
        PipesHolder.AddChild(newPipes);
    }

    private void StopPipes()
    {
        SpawnTimer.Stop();
        foreach (Node pipe in PipesHolder.GetChildren())
        {
            pipe.SetProcess(false);
        }
    }

    private void OnSpawnTimerTimeout()
    {
        SpawnPipes();
    }

    private void OnGameOver()
    {
        StopPipes();
        EngineSound.Stop();
        GameOverSound.Play();
    }
}
