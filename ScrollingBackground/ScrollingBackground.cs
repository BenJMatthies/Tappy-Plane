using Godot;
using System;

public partial class ScrollingBackground : ParallaxBackground
{
    const float SPEED = 120.0F;
    GameManager gameManager;
	
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        gameManager = GetNode<GameManager>("/root/GameManager");
        Callable onGameOverCallable = new(this, "OnGameOver");
        gameManager.Connect("OnGameOver", onGameOverCallable);
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
		Vector2 newOffset = ScrollOffset + new Vector2(SPEED*(float)delta*-1,0);
        ScrollOffset = newOffset;
    }

    private void OnGameOver()
    {
        SetProcess(false);
    }
}
