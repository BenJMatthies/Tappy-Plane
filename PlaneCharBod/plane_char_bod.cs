using Godot;
using System;

public partial class plane_char_bod : CharacterBody2D
{
    const double GRAVITY = 17;
    const double POWER = -300.0;
    AnimationPlayer _player;
    AnimatedSprite2D _planeSprite;

    // [Signal]
    // public delegate void OnPlaneDiedEventHandler();
    GameManager gameManager;

    public override void _Ready()
    {
        _player = GetNode<AnimationPlayer>("AnimationPlayer");
        _planeSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
        gameManager = (GameManager)GetNode("/root/GameManager");
    }

    public override void _PhysicsProcess(double delta)
    {
        Fall();
        Fly();
        MoveAndSlide();

        if (IsOnFloor())
        {
            Die();
        }
    }

    private void Fall()
    {
        Velocity += new Vector2(Velocity.X, (float)GRAVITY);
    }

    private void Fly()
    {
        if (Input.IsActionJustPressed("fly"))
        {
            Velocity = new Vector2(Velocity.X, (float)POWER);
            _player.Play("fly");
        }
    }

    private void Die()
    {
        _planeSprite.Stop();
        // EmitSignal("OnPlaneDied");
        // GameManager gameManager = (GameManager)GetNode("/root/GameManager");
        gameManager.EmitSignal("OnGameOver");
        SetPhysicsProcess(false);
    }
}
