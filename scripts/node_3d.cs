using Godot;
using System;

public partial class node_3d : Node3D
{
	// Called when the node enters the scene tree for the first time.
    private int _a = 2;
    private string _b = "textvar";

    public override void _Ready()
    {
        var newPosition = Position;
		newPosition.X = 100.0f;
		Position = newPosition;
        GD.Print("Hello from C# to Godot :)");
    }

    public override void _Process(double delta)
    {
        // Called every frame. Delta is time since the last frame.
        // Update game logic here.
    }
}
