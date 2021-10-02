using System;
using Godot;

public class Player : KinematicBody
{
    [Export]
    private float _speed = 10.0f;
    [Export]
    private float _acceleration = 5.0f;
    [Export]
    private float _gravity = 0.98f;
    [Export]
    private float _jump_power = 30.0f;

    private Vector3 _velocity;

    public override void _Ready()
    {

    }

    public override void _PhysicsProcess(float delta)
    {
        var head_basis = GlobalTransform.basis;
        var direction = new Vector3();

        // forward-back movement
        if (Input.IsActionPressed("move_forward"))
        {
            // -Z is forward in Godot
            direction -= head_basis.z;
        }
        else if (Input.IsActionPressed("move_backward"))
        {
            direction += head_basis.z;
        }

        // left-right movement
        if (Input.IsActionPressed("move_left"))
        {
            direction -= head_basis.x;
        }
        else if (Input.IsActionPressed("move_right"))
        {
            direction += head_basis.x;
        }

        // normalize direction
        direction = direction.Normalized();

        var old_y_velocity = _velocity.y;
        _velocity = _velocity.LinearInterpolate(direction * _speed, _acceleration * delta);
        // gravity
        _velocity.y = old_y_velocity - _gravity;

        // jumping
        if (Input.IsActionJustPressed("jump") && this.IsOnFloor())
        {
            _velocity.y += _jump_power;
        }

        _velocity = MoveAndSlide(_velocity, Vector3.Up);
    }
}
