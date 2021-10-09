using System;
using Godot;

public class GameController : Node
{
    private Spatial _main_camera;

    public override void _Ready()
    {
        _main_camera = GetNode<Spatial>("MainCamera");
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        if (Input.IsActionJustPressed("RotateWorldLeft"))
        {
            _main_camera.RotateY(-Mathf.Pi / 2);
        }
        else if (Input.IsActionJustPressed("RotateWorldRight"))
        {
            _main_camera.RotateY(Mathf.Pi / 2);
        }
    }
}
