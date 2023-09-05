using Godot;
using System;

public partial class ScrollingLayer : ParallaxLayer
{
    Sprite2D sprite;
    [Export] Texture2D texture;
    [Export] double scrollScale;
    [Export] double textureX;
    [Export] double textureY;
	
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        sprite = GetNode<Sprite2D>("Sprite2D");
        textureX = 1920.0;
        textureY = 1080.0;

        MotionScale = new Vector2((float)scrollScale, 0);
        double scaleFactor = GetViewportRect().Size.Y / textureY;
        sprite.Texture = texture;
        sprite.Scale = new Vector2((float)scaleFactor, (float)scaleFactor);
        MotionMirroring = new Vector2((float)(textureX * scaleFactor), 0);
    }
}
