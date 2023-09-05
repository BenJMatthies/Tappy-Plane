using Godot;
using System;

public partial class plane_char_bod : CharacterBody2D
{
    const double GRAVITY = 17;
    const double POWER = -300.0;
    public bool dead = false;
    AnimationPlayer _player;
    AnimatedSprite2D _planeSprite;

    // [Signal] public delegate void OnPlaneDiedEventHandler();
    GameManager gameManager;

    public override void _Ready()
    {
        _player = GetNode<AnimationPlayer>("AnimationPlayer");
        _planeSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
        gameManager = GetNode<GameManager>("/root/GameManager");
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

    public void Die()
    {
        if(!dead)
        {
            dead = true;
            _planeSprite.Stop();
            // EmitSignal("OnPlaneDied");
            SetPhysicsProcess(false);
            gameManager.EmitSignal("OnGameOver");
        }
    }
}
