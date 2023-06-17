using Godot;
using System;

public partial class node_3d : Node3D
{
	// Called when the node enters the scene tree for the first time.
	private Node3D nodeTest;

	public override void _Ready()
	{
		base._Ready();

		nodeTest = new Node3D(); // Create a new Sprite2D.
		AddChild(nodeTest); // Add it as a child of this node.
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
