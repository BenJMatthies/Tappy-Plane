using Godot;
using System;

public partial class pipes : Node2D
{
    const double SCROLL_SPEED = 120.0;
    AudioStreamPlayer ScoreSound;
    GameManager gameManager;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        ScoreSound = GetNode<AudioStreamPlayer>("ScoreSound");
        gameManager = GetNode<GameManager>("/root/GameManager");
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
        Position = new Vector2(Position.X - (float)(SCROLL_SPEED * delta), Position.Y);
    }

    private void ScreenExited()
    {
        QueueFree();
    }

    public void signal_OnPipeBodyEntered(Node2D body)
    {
        if (body is plane_char_bod)
        {
            plane_char_bod planeBody = (plane_char_bod)body;
            planeBody.Die();
        }
    }

    public void signal_OnLaserBodyEntered(plane_char_bod body)
    {
        ScoreSound.Play();
        gameManager.incrementScore();
    }
}
