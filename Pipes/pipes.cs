using Godot;
using System;

public partial class pipes : Node2D
{
    const double SCROLL_SPEED = 120.0;
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
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
}
